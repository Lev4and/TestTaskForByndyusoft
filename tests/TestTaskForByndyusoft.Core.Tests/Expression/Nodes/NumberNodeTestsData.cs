using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class NumberNodeTestsData
    {
        public class Calculate : TheoryData<NumberNode, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(10), 10);
                Add(new NumberNode(-10), -10);
            }
        }
    }
}
