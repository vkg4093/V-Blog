using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace V.Blog.Test.Framework
{
    public static class Mapper
    {

        public static List<TOutput> ToMap<TInput, TOutput>(this List<TInput> items, Converter<TInput, TOutput> converter)
        {
            var models = new List<TOutput>();
            if (items != null && items.Count > 0)
                models = items.ConvertAll(converter);
            return models;
        }
        public static List<TOutput> ToMap<TInput, TOutput>(this List<TInput> items)
        {

            var models = new List<TOutput>();
            if (items != null && items.Count() > 0)
                models = items.ToList().ConvertAll<TOutput>(ToMap<TInput, TOutput>);
            return models;
        }

        public static TOutput ToMap<TInput, TOutput>(this TInput item)
        {
            TOutput outobj = default(TOutput);
            outobj = Activator.CreateInstance<TOutput>();
            if (item != null)
            {
                TInput inObj = Activator.CreateInstance<TInput>();
                var inProperties = inObj.GetType().GetProperties();
                foreach (var o in inProperties)
                {
                    PropertyInfo prop = outobj.GetType().GetProperty(o.Name);
                    object value = o.GetValue(item, null);
                    if (prop != null && value != null)
                    {
                        prop.SetValue(outobj, value, null);
                    }

                }
            }
            return outobj;
        }
        public static Expression<Func<TTo, bool>> ConvertExpression<TFrom, TTo>(this Expression<Func<TFrom, bool>> expr)
        {
            Dictionary<Expression, Expression> substitutues = new Dictionary<Expression, Expression>();
            var oldParam = expr.Parameters[0];
            var newParam = Expression.Parameter(typeof(TTo), oldParam.Name);
            substitutues.Add(oldParam, newParam);
            Expression body = ConvertNode(expr.Body, substitutues);
            return Expression.Lambda<Func<TTo, bool>>(body, newParam);
        }
        static Expression ConvertNode(Expression node, IDictionary<Expression, Expression> subst)
        {
            if (node == null) return null;
            if (subst.ContainsKey(node)) return subst[node];

            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return node;
                case ExpressionType.MemberAccess:
                    {
                        var me = (MemberExpression)node;
                        var newNode = ConvertNode(me.Expression, subst);
                        return Expression.MakeMemberAccess(newNode, newNode.Type.GetMember(me.Member.Name).Single());
                    }
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal: /* will probably work for a range of common binary-expressions */
                    {
                        var be = (BinaryExpression)node;
                        return Expression.MakeBinary(be.NodeType, ConvertNode(be.Left, subst), ConvertNode(be.Right, subst), be.IsLiftedToNull, be.Method);
                    }

                default:
                    throw new NotSupportedException(node.NodeType.ToString());
            }
        }

    }
}
