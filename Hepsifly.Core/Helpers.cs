using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Core
{
    public static class Helpers
    {
        public static Expression<Func<T, bool>> MakeExpression<T>(string key, string value)
        {
            var p = Expression.Parameter(typeof(T), "x");
            return Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(p, key), Expression.Constant(value)), p);
        }
    }
}
