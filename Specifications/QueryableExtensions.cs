using System.Linq;

namespace Specifications
{
    /// <summary>
    /// Specification <see cref="IQueryable"/> extensions.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Filters a sequence of values based on <paramref name="specification"/>.
        /// </summary>
        /// <typeparam name="TSource">Type.</typeparam>
        /// <param name="source">Sequence.</param>
        /// <param name="specification">Specification.</param>
        /// <returns>An <see cref="IQueryable"/>.</returns>
        public static IQueryable<TSource> Where<TSource>(
            this IQueryable<TSource> source, SpecificationBase<TSource> specification)
        {
            return source.Where(specification.ToExpression());
        }
    }
}