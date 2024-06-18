using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class MultiplyOperatorTestsData
    {
        public class Calculate : TheoryData<Node, Node, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(4), new NumberNode(0), 0);
                Add(new NumberNode(4), new NumberNode(2), 8);
                Add(new NumberNode(4), new NumberNode(0.5m), 2);
                Add(new NumberNode(4), new NumberNode(1.5m), 6);
                Add(new NumberNode(-4), new NumberNode(1.5m), -6);
                Add(new NumberNode(-4), new NumberNode(-1.5m), 6);
            }
        }
    }
}
