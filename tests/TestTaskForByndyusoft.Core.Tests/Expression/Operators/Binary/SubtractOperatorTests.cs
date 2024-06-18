using System.Numerics;
using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class SubtractOperatorTests
    {
        private readonly SubtractOperator _subtractOperator;

        public SubtractOperatorTests()
        {
            _subtractOperator = new SubtractOperator();
        }

        [Theory]
        [ClassData(typeof(SubtractOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(Node left, Node right, decimal expectedResult)
        {
            var actual = _subtractOperator.Calculate(left, right);

            Assert.Equal(expectedResult, actual);
        }
    }
}
