using System;
using System.Linq.Expressions;

namespace Specifications.UnitTests.ClassSpecifications
{
    public class TownSpecification : SpecificationBase<Person>
    {
        private readonly string _town;

        public TownSpecification(string town)
        {
            _town = town;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => person.Hometown == _town;
        }
    }
}