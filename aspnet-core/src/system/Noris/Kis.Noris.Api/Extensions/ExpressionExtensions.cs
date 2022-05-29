using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Kis.Noris.Api.Extensions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Получает объект <see cref="PropertyInfo"/>, описывающий свойство, вызванное в
        /// переданном лямбда-выражении.
        /// </summary>
        /// <typeparam name="T">Тип входного объекта лямбды</typeparam>
        /// <typeparam name="TResult">Тип возвращаемый вызванным свойством</typeparam>
        /// <param name="getPropertyLambda">Лямбда-выражение</param>
        /// <returns>Возвращает описательный объект некоторого свойства другого объекта</returns>
        /// <exception cref="ArgumentException">Лямбда-выражение неявляется выражением вызова свойства объекта, 
        /// либо не удалось получить данные о вызванном свойстве</exception>
        public static PropertyInfo GetPropertyFromExpression<T, TResult>(this Expression<Func<T, TResult>> getPropertyLambda)
        {
            MemberExpression exp;

            var unaryExpression = getPropertyLambda.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var operand = unaryExpression.Operand as MemberExpression;
                if (operand != null)
                {
                    exp = operand;
                }
                else
                {
                    throw new ArgumentException("Expression is not an access to object property");
                }
            }
            else
            {
                var memberExpression = getPropertyLambda.Body as MemberExpression;
                if (memberExpression != null)
                {
                    exp = memberExpression;
                }
                else
                {
                    throw new ArgumentException("Expression is not an access to object property");
                }
            }

            return (PropertyInfo) exp.Member;
        }
    }
}
