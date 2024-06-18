using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class BinaryOperatorTests
    {
        [Theory]
        [ClassData(typeof(BinaryOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(BinaryOperator binaryOperator, Node left,
            Node right, decimal expectedResult)
        {
            var actual = binaryOperator.Calculate(left, right);

            Assert.Equal(expectedResult, actual);
        }
    }
}
