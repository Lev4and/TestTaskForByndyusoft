using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Unary
{
    public class UnaryOperatorTests
    {
        [Theory]
        [ClassData(typeof(UnaryOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(UnaryOperator unaryOperator, Node node, 
            decimal expectedResult)
        {
            var actual = unaryOperator.Calculate(node);

            Assert.Equal(expectedResult, actual);
        }
    }
}
