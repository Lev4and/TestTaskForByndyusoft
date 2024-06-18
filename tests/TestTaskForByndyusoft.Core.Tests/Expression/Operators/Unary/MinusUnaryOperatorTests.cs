using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Unary
{
    public class MinusUnaryOperatorTests
    {
        private readonly MinusUnaryOperator _minusUnaryOperator;

        public MinusUnaryOperatorTests()
        {
            _minusUnaryOperator = new MinusUnaryOperator();
        }

        [Theory]
        [ClassData(typeof(MinusUnaryOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(Node node, decimal expectedResult)
        {
            var actual = _minusUnaryOperator.Calculate(node);

            Assert.Equal(expectedResult, actual);
        }
    }
}
