using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class NodeTests
    {
        [Theory]
        [ClassData(typeof(NodeTestsData.Calculate))]
        public void Calculate_ShouldReturnExpectedResult(Node node, decimal expectedResult)
        {
            var actual = node.Calculate();

            Assert.Equal(expectedResult, actual);
        }
    }
}
