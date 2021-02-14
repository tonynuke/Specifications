using System;
using System.Linq;
using FluentAssertions;
using Specifications;
using Xunit;

namespace SpecificationsTests
{
    public class SpecificationsTests
    {
        private readonly IQueryable<int> _collection;

        public SpecificationsTests()
        {
            _collection = Enumerable.Range(0, 100).AsQueryable();
        }

        [Fact]
        public void CreateSpecification_When_ExpressionsIsNull_Should_ThrowsException()
        {
            Action creation = () => Specification<int>.Create(null);
            creation.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void UseSpecification_When_SingleSpecification_Should_EqualsToTemplate()
        {
            const int begin = 5;
            const int end = 15;
            const int count = end - begin;

            var expectedData = Enumerable.Range(begin, count);

            var specification = Specification<int>.Create(i => i >= begin && i < end);
            var actualData = _collection.Where(specification.ToExpression());

            actualData.Should().BeEquivalentTo(expectedData);
        }

        [Fact]
        public void UseSpecification_When_AndSpecification_Should_EqualsToTemplate()
        {
            const int begin = 5;
            const int end = 15;
            const int count = end - begin;

            var expectedData = Enumerable.Range(begin, count);

            var specification = Specification<int>.Create(i => i >= begin)
                .And(Specification<int>.Create(i => i < end));
            var actualData = _collection.Where(specification.ToExpression());

            actualData.Should().BeEquivalentTo(expectedData);
        }

        [Fact]
        public void UseSpecification_When_IsSatisfied_ShouldBe_True()
        {
            const int begin = 5;
            const int end = 10;

            var specification = Specification<int>.Create(i => i >= begin && i < end);

            specification.IsSatisfiedBy(begin).Should().BeTrue();
        }

        [Fact]
        public void UseSpecification_When_IsNotSatisfied_ShouldBe_False()
        {
            const int begin = 5;
            const int end = 10;
            const int outOfRange = 15;

            var specification = Specification<int>.Create(i => i >= begin && i < end);

            specification.IsSatisfiedBy(outOfRange).Should().BeFalse();
        }

        [Fact]
        public void UseAllSpecification_When_AllSpecification_Should_EqualsToTemplate()
        {
            var expectedData = _collection;

            var specification = Specification<int>.All;
            var actualData = _collection.Where(specification.ToExpression());

            actualData.Should().BeEquivalentTo(expectedData);
        }
    }
}
