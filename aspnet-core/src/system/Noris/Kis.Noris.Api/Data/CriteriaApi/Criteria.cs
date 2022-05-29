using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kis.Noris.Api.Data.CriteriaApi
{
    public delegate bool Criterion<in T>(T entity);

    public interface ICriteria
    {
        LambdaExpression CriteriaExpression { get; }
    }

    public interface ICriteria<in T> : ICriteria where T : class
    {
    }

    public abstract class Criteria : ICriteria
    {
        public static Criteria<T> For<T>() where T : class
        {
            return new CriteriaImpl<T>(null);
        }

        public static Criteria<T> For<T>(Expression<Criterion<T>> criteriaExpression) where T : class
        {
            return new CriteriaImpl<T>(criteriaExpression);
        }

        public static ICriteria<T> And<T>(ICriteria<T> left, ICriteria<T> right) where T : class
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            return new AndCriteria<T>(left, right);
        }

        public static ICriteria<T> Or<T>(ICriteria<T> left, ICriteria<T> right) where T : class
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            return new OrCriteria<T>(left, right);
        }

        public static ICriteria<T> Not<T>(ICriteria<T> single) where T : class
        {
            if (single == null) throw new ArgumentNullException(nameof(single));

            return new NotCriteria<T>(single);
        }

        protected static LambdaExpression Compose(LambdaExpression single, Func<Expression, Expression> merge)
        {
            return single == null ? null : Expression.Lambda(merge(single.Body), single.Parameters);
        }

        protected static LambdaExpression Compose(LambdaExpression first, LambdaExpression second, Func<Expression, Expression, Expression> merge)
        {
            if (first == null)
                return second;

            if (second == null)
                return first;

            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda(merge(first.Body, secondBody), first.Parameters);
        }

        public abstract LambdaExpression CriteriaExpression { get; }
    }

    public abstract class Criteria<T> : Criteria, ICriteria<T> where T:class
    {
        public override LambdaExpression CriteriaExpression => Criterion;

        public abstract Expression<Criterion<T>> Criterion { get; }
    }

    public class AndCriteria<T> : Criteria, ICriteria<T> where T : class
    {
        public ICriteria<T> Left { get; }
        public ICriteria<T> Right { get; }

        public AndCriteria(ICriteria<T> left, ICriteria<T> right)
        {
            Left = left;
            Right = right;
        }

        public override LambdaExpression CriteriaExpression => 
            Compose(Left.CriteriaExpression, Right.CriteriaExpression, Expression.AndAlso);
    }

    public class OrCriteria<T> : Criteria, ICriteria<T> where T : class
    {
        public ICriteria<T> Left { get; }
        public ICriteria<T> Right { get; }

        public OrCriteria(ICriteria<T> left, ICriteria<T> right)
        {
            Left = left;
            Right = right;
        }

        public override LambdaExpression CriteriaExpression => 
            Compose(Left.CriteriaExpression, Right.CriteriaExpression, Expression.OrElse);
    }

    public class NotCriteria<T> : Criteria, ICriteria<T> where T : class
    {
        public ICriteria<T> Single { get; }

        public NotCriteria(ICriteria<T> single)
        {
            Single = single;
        }

        public override LambdaExpression CriteriaExpression => 
            Compose(Single.CriteriaExpression, Expression.Not);
    }

    internal class CriteriaImpl<T> : Criteria<T> where T : class
    {
        public override Expression<Criterion<T>> Criterion { get; }

        internal CriteriaImpl(Expression<Criterion<T>> expression)
        {
            Criterion = expression;
        }
    }
}