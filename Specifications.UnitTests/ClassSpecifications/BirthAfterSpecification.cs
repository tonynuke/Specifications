using System;
using System.Linq.Expressions;

namespace Specifications.UnitTests.ClassSpecifications
{
    public class BirthAfterSpecification : SpecificationBase<Person>
    {
        private readonly DateTime _birthDate;

        public BirthAfterSpecification(DateTime birthDate)
        {
            _birthDate = birthDate;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => person.BirthDate > _birthDate;
        }
    }
}