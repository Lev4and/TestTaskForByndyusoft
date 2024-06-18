using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class UnaryNodeTests
    {
        [Theory]
        [ClassData(typeof(UnaryNodeTestsData.Calculate))]
        public void Calculate_ShouldReturnExpectedResult(Node node, UnaryOperator unaryOperator, decimal expectedResult)
        {
            var unaryNode = new UnaryNode(node, unaryOperator);

            var actual = unaryNode.Calculate();

            Assert.Equal(expectedResult, actual);
        }
    }
}
