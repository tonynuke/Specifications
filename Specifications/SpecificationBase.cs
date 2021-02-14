using System;
using System.Linq.Expressions;

namespace Specifications
{
    /// <summary>
    /// Base specification.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public abstract class SpecificationBase<T>
    {
        /// <summary>
        /// All specification.
        /// </summary>
        public static readonly SpecificationBase<T> All = new AllSpecification<T>();

        public static SpecificationBase<T> operator &(
            SpecificationBase<T> left, SpecificationBase<T> right) => left.And(right);

        public static SpecificationBase<T> operator |(
            SpecificationBase<T> left, SpecificationBase<T> right) => left.Or(right);

        public static SpecificationBase<T> operator !(SpecificationBase<T> spec) => spec.Not();

        /// <summary>
        /// Returns expression.
        /// </summary>
        /// <returns>Expression.</returns>
        public abstract Expression<Func<T, bool>> ToExpression();

        /// <summary>
        /// Gets a value indicating whether entity is satisfied by specification.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>
        /// <see langword="true"/> if entity is satisfied by specification;
        /// <see langword="false"/> if entity is not satisfied by specification.
        /// </returns>
        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        /// <summary>
        /// Link specification with and condition.
        /// </summary>
        /// <param name="specification">Specification.</param>
        /// <returns>Specification <see cref="SpecificationBase{T}"/>.</returns>
        public SpecificationBase<T> And(SpecificationBase<T> specification)
        {
            if (this == All)
            {
                return specification;
            }

            return specification == All
                ? this
                : new AndSpecification<T>(this, specification);
        }

        /// <summary>
        /// Link specification with and condition.
        /// </summary>
        /// <param name="specification">Specification.</param>
        /// <returns>Specification <see cref="SpecificationBase{T}"/>.</returns>
        public SpecificationBase<T> Or(SpecificationBase<T> specification)
        {
            if (this == All || specification == All)
            {
                return All;
            }

            return new OrSpecification<T>(this, specification);
        }

        /// <summary>
        /// Invert specification condition.
        /// </summary>
        /// <returns>Specification <see cref="SpecificationBase{T}"/>.</returns>
        public SpecificationBase<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}