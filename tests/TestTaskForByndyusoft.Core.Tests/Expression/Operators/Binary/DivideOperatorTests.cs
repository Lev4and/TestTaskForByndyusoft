using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class DivideOperatorTests
    {
        private readonly DivideOperator _divideOperator;

        public DivideOperatorTests()
        {
            _divideOperator = new DivideOperator();    
        }

        [Theory]
        [ClassData(typeof(DivideOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(Node left, Node right, decimal expectedResult)
        {
            var actual = _divideOperator.Calculate(left, right);

            Assert.Equal(expectedResult, actual);
        }
    }
}
