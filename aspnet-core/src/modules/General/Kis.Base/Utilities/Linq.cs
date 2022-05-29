using System;
using System.Linq.Expressions;

namespace Kis.Base.Utilities
{
    public static class Linq
    {
        // Returns the given anonymous method as a lambda expression
        public static Expression<Func<T, TResult>>
            Expr<T, TResult>(Expression<Func<T, TResult>> f)
        {
            return f;
        }

        // Returns the given anonymous method as a lambda expression
        public static Expression<Func<T1, T2, TResult>>
            Expr<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> f)
        {
            return f;
        }

        // Returns the given anonymous function as a Func delegate
        public static Func<T, TResult>
            Func<T, TResult>(Func<T, TResult> f)
        {
            return f;
        }

        // Returns the given anonymous function as a Func delegate
        public static Func<T1, T2, TResult>
            Func<T1, T2, TResult>(Func<T1, T2, TResult> f)
        {
            return f;
        }
    }
}
