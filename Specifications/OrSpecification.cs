using System;
using System.Linq.Expressions;

namespace Specifications
{
    /// <summary>
    /// Or specification.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    internal sealed class OrSpecification<T> : SpecificationBase<T>
    {
        private readonly SpecificationBase<T> _left;

        private readonly SpecificationBase<T> _right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrSpecification{T}"/> class.
        /// </summary>
        /// <param name="left">Left specification.</param>
        /// <param name="right">Right specification.</param>
        public OrSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }

        /// <inheritdoc/>
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

            return (Expression<Func<T, bool>>)Expression.Lambda(
                Expression.OrElse(leftExpression.Body, invokedExpression), leftExpression.Parameters);
        }
    }
}