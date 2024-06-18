using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class BinaryNodeTests
    {
        [Theory]
        [ClassData(typeof(BinaryNodeTestsData.Calculate))]
        public void Calculate_ShouldReturnExpectedResult(Node left, Node right, 
            BinaryOperator binaryOperator, decimal expectedResult)
        {
            var binaryNode = new BinaryNode(left, right, binaryOperator);

            var actual = binaryNode.Calculate();

            Assert.Equal(expectedResult, actual);
        }
    }
}
