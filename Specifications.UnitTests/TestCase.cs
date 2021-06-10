using System.Collections.Generic;

namespace Specifications.UnitTests
{
    public class TestCase
    {
        public TestCase(SpecificationBase<int> specification, IEnumerable<int> expectedResult)
        {
            Specification = specification;
            ExpectedResult = expectedResult;
        }

        public SpecificationBase<int> Specification { get; }

        public IEnumerable<int> ExpectedResult { get; }
    }
}