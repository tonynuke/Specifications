using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specifications
{
    /// <summary>
    /// Not specification.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    internal sealed class NotSpecification<T> : SpecificationBase<T>
    {
        private readonly SpecificationBase<T> _specification;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{T}"/> class.
        /// </summary>
        /// <param name="specification">Specification.</param>
        public NotSpecification(SpecificationBase<T> specification)
        {
            _specification = specification;
        }

        /// <inheritdoc/>
        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = _specification.ToExpression();
            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters);
        }
    }
}