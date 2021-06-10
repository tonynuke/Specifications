using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Specifications.UnitTests.ClassSpecifications
{
    public class ClassSpecificationTests
    {
        [Fact]
        public void Can_apply_specification()
        {
            var expectedPerson = new Person("Ivan", "Moscow", DateTime.Parse("08/18/1985"));
            var persons = new List<Person>
            {
                new("John", "Ufa", DateTime.Parse("08/18/1985")),
                expectedPerson,
                new("Peter", "Moscow", DateTime.Parse("08/18/1965")),
            };

            var birthAfterSpecification = new BirthAfterSpecification(DateTime.Parse("08/18/1980"));
            var townSpecification = new TownSpecification("Moscow");

            var specification = birthAfterSpecification.And(townSpecification);
            var actualPerson = persons.AsQueryable().SingleOrDefault(specification.ToExpression());

            actualPerson.Name.Should().Be(expectedPerson.Name);
            actualPerson.BirthDate.Should().Be(expectedPerson.BirthDate);
            actualPerson.Hometown.Should().Be(expectedPerson.Hometown);

            specification.IsSatisfiedBy(expectedPerson).Should().BeTrue();
        }
    }
}