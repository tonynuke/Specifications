using System;
using System.Linq.Expressions;

namespace Specifications
{
    /// <summary>
    /// Specification.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public sealed class Specification<T> : SpecificationBase<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        private Specification(Expression<Func<T, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Specification{T}"/> class.
        /// </summary>
        /// <param name="expression">Expression.</param>
        /// <returns>Specification <see cref="Specification{T}"/>.</returns>
        public static Specification<T> Create(Expression<Func<T, bool>> expression)
        {
            return new (expression);
        }

        /// <inheritdoc/>
        public override Expression<Func<T, bool>> ToExpression()
        {
            return _expression;
        }
    }
}