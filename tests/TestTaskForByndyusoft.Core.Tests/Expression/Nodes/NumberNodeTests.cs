using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class NumberNodeTests
    {
        [Theory]
        [ClassData(typeof(NumberNodeTestsData.Calculate))]
        public void Calculate_ShouldReturnExpectedResult(NumberNode numberNode, decimal expectedResult)
        {
            var actual = numberNode.Calculate();

            Assert.Equal(expectedResult, actual);
        }
    }
}
