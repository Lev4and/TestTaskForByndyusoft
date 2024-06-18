using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Nodes
{
    public class UnaryNodeTestsData
    {
        public class Calculate : TheoryData<Node, UnaryOperator, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(20), new MinusUnaryOperator(), -20);
                Add(new NumberNode(-20), new MinusUnaryOperator(), 20);
            }
        }
    }
}
