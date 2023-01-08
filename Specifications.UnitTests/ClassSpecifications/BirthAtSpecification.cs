using System;
using System.Linq.Expressions;

namespace Specifications.UnitTests.ClassSpecifications
{
    public class BirthAtSpecification : SpecificationBase<Person>
    {
        private readonly DateTime _birthDate;

        public BirthAtSpecification(DateTime birthDate)
        {
            _birthDate = birthDate;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => person.BirthDate == _birthDate;
        }
    }
}