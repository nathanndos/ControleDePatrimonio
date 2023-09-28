using System;
using System.Linq.Expressions;
using System.Windows.Controls;

namespace Patrimonio.Util
{
    public static class Extensions
    {
        public static bool isEmpty(this Guid value) => value.Equals(Guid.Empty);
        public static bool isEmpty(this string value) => value?.Equals(string.Empty) ?? true;
        public static bool isNotEmpty(this string value) => !value.isEmpty();
        public static bool isApagado(this int value) => value.Equals(-1);
        public static bool isNotApagado(this int value) => !value.isApagado();
        public static string getString(this TextBox value) => value.Text?.Trim() ?? string.Empty;
        public static bool isZero(this int value) => value.Equals(0);

        public static Expression<Func<T, bool>> and<T>(this Expression<Func<T, bool>> expressionLeft, Expression<Func<T, bool>> expressionRight)
        {
            var parameter = Expression.Parameter(typeof(T), nameof(T));
            return Expression.Lambda<Func<T, bool>>(Expression.And(Expression.Invoke(expressionLeft, parameter), Expression.Invoke(expressionRight, parameter)), parameter);
        }
    }
}
