using System;
using System.Linq.Expressions;

namespace Specification
{
    public sealed class Specification<T> : SpecificationBase<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        public Specification(Expression<Func<T, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return _expression;
        }
    }
}