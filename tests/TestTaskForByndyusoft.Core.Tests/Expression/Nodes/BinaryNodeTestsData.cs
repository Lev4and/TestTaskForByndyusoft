using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class BinaryNodeTestsData
    {
        public class Calculate : TheoryData<Node, Node, BinaryOperator, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(20), new NumberNode(10), new AddOperator(), 30);
                Add(new NumberNode(20), new NumberNode(10), new SubtractOperator(), 10);
                Add(new NumberNode(20), new NumberNode(10), new MultiplyOperator(), 200);
                Add(new NumberNode(20), new NumberNode(10), new DivideOperator(), 2);
            }
        }
    }
}
