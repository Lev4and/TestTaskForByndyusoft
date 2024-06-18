using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class AddOperatorTests
    {
        private readonly AddOperator _addOperator;

        public AddOperatorTests()
        {
            _addOperator = new AddOperator();
        }

        [Theory]
        [ClassData(typeof(AddOperatorTestsData.Calculate))]
        public void Calculate_WithParam_ShouldReturnExpectedResult(Node left, Node right, decimal expectedResult)
        {
            var actual = _addOperator.Calculate(left, right);

            Assert.Equal(expectedResult, actual);
        }
    }
}
