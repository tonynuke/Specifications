using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Specifications.UnitTests
{
    public class SpecificationsTests
    {
        private const int Count = 5;
        private readonly IQueryable<int> _collection;

        public SpecificationsTests()
        {
            _collection = Enumerable.Range(0, Count).AsQueryable();
        }

        [Fact]
        public void Can_not_create_a_specification_when_the_expression_is_null()
        {
            Action creation = () => Specification<int>.Create(null);
            creation.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Can_apply_specifications(TestCase testCase)
        {
            var actualData = _collection.Where(testCase.Specification);
            actualData.Should().BeEquivalentTo(testCase.ExpectedResult);
        }

        public static IReadOnlyCollection<object[]> TestCases = new[]
        {
            new object[]
            {
                new TestCase(
                    Specification<int>.All,
                    Enumerable.Range(0, Count))
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 0),
                    Enumerable.Range(0, Count))
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2).Or(Specification<int>.Create(i => i <= 2)),
                    Enumerable.Range(0, Count))
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2) | (Specification<int>.Create(i => i <= 2)),
                    Enumerable.Range(0, Count))
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2).And(Specification<int>.Create(i => i <= 2)),
                    new[] {2})
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2) & (Specification<int>.Create(i => i <= 2)),
                    new[] {2})
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2).Not(),
                    new[] {0, 1})
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2).Not().Or(Specification<int>.All),
                    Enumerable.Range(0, Count))
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2).Not().Or(Specification<int>.All).Not(),
                    Enumerable.Empty<int>())
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.Create(i => i >= 2).And(Specification<int>.All),
                    new[] {2, 3, 4})
            },
            new object[]
            {
                new TestCase(
                    Specification<int>.All.And(Specification<int>.Create(i => i >= 2)),
                    new[] {2, 3, 4})
            },
            new object[]
            {
                new TestCase(
                    !Specification<int>.Create(i => i >= 2),
                    new[] {0, 1})
            },
        };
    }
}
