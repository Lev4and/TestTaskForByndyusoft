using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class SubtractOperatorTestsData
    {
        public class Calculate : TheoryData<Node, Node, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(4), new NumberNode(0), 4);
                Add(new NumberNode(4), new NumberNode(2), 2);
                Add(new NumberNode(2), new NumberNode(4), -2);
                Add(new NumberNode(-2), new NumberNode(4), -6);
                Add(new NumberNode(-2), new NumberNode(-4), 2);
                Add(new NumberNode(-6), new NumberNode(-3.5m), -2.5m);
            }
        }
    }
}
