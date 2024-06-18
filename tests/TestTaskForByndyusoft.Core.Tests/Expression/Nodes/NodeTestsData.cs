using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class NodeTestsData
    {
        public class Calculate : TheoryData<Node, decimal>
        {
            public Calculate()
            {
                Add(new BinaryNode(new NumberNode(20), new NumberNode(10), new AddOperator()), 30);
                Add(new BinaryNode(new NumberNode(20), new NumberNode(10), new SubtractOperator()), 10);
                Add(new BinaryNode(new NumberNode(20), new NumberNode(10), new MultiplyOperator()), 200);
                Add(new BinaryNode(new NumberNode(20), new NumberNode(10), new DivideOperator()), 2);

                Add(new NumberNode(10), 10);
                Add(new NumberNode(-10), -10);

                Add(new UnaryNode(new NumberNode(20), new MinusUnaryOperator()), -20);
                Add(new UnaryNode(new NumberNode(-20), new MinusUnaryOperator()), 20);
            }
        }
    }
}
