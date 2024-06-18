using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class AddOperatorTestsData
    {
        public class Calculate : TheoryData<Node, Node, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(0), new NumberNode(0), 0);
                Add(new NumberNode(5), new NumberNode(2), 7);
                Add(new NumberNode(2), new NumberNode(5), 7);
                Add(new NumberNode(2), new NumberNode(2.2m), 4.2m);
                Add(new NumberNode(-5), new NumberNode(10), 5);
                Add(new NumberNode(-5), new NumberNode(-10), -15);
            }
        }
    }
}
