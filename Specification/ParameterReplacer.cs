using System;
using System.Linq.Expressions;

namespace Specification
{
    internal class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);
    }
}