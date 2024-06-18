using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class DivideOperatorTestsData
    {
        public class Calculate : TheoryData<Node, Node, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(4), new NumberNode(2), 2);
                Add(new NumberNode(10), new NumberNode(2), 5);
                Add(new NumberNode(6), new NumberNode(4), 1.5m);
                Add(new NumberNode(10), new NumberNode(0.5m), 20);
                Add(new NumberNode(-10), new NumberNode(0.5m), -20);
                Add(new NumberNode(-10), new NumberNode(-0.5m), 20);
            }
        }
    }
}
