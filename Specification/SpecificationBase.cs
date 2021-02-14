using System;
using System.Linq.Expressions;

namespace Specification
{
    public abstract class SpecificationBase<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public SpecificationBase<T> And(SpecificationBase<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public SpecificationBase<T> Or(SpecificationBase<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
    }
}