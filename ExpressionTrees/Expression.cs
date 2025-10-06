using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    public class Expressions
    {
        public static Expression<Func<T, bool>> BuildPredicate<T>(FilterRequest filter)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, filter.Field);
            var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

            Expression body = filter.Operator switch
            {
                "Equal" => Expression.Equal(property, constant),
                "NotEqual" => Expression.NotEqual(property, constant),
                "GreaterThan" => Expression.GreaterThan(property, constant),
                "LessThan" => Expression.LessThan(property, constant),
                "Contains" => Expression.Call(property, "Contains", null, constant),
                        _ => throw new NotSupportedException($"Operator {filter.Operator} not supported")

            };

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    public class FilterRequest
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; } //0 Male 1 Female
    }
}
