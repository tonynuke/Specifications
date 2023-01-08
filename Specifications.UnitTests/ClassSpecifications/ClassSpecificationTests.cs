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
        public void Apply_specification()
        {
            var dateTime = DateTime.UtcNow.Date;
            var expectedDateTime = dateTime.AddYears(5);

            var expectedPerson = new Person("Ivan", "Moscow", expectedDateTime);
            var persons = new List<Person>
            {
                new("John", "Ufa", dateTime),
                expectedPerson,
                new("Peter", "Moscow", dateTime),
            };

            var birthAfterSpecification = new BirthAtSpecification(expectedDateTime);
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