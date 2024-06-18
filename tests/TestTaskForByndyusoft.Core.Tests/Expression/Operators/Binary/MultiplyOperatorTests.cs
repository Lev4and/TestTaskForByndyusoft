using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class MultiplyOperatorTests
    {
        private readonly MultiplyOperator _multiplyOperator;

        public MultiplyOperatorTests()
        {
            _multiplyOperator = new MultiplyOperator();
        }

        [Theory]
        [ClassData(typeof(MultiplyOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(Node left, Node right, decimal expectedResult)
        {
            var actual = _multiplyOperator.Calculate(left, right);

            Assert.Equal(expectedResult, actual);
        }
    }
}
