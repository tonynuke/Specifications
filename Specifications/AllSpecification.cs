using System;
using System.Linq.Expressions;

namespace Specifications
{
    /// <summary>
    /// All specification.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    internal sealed class AllSpecification<T> : SpecificationBase<T>
    {
        /// <inheritdoc/>
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}