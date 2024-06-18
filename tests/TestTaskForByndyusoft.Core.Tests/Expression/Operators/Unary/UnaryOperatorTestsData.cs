using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Unary
{
    public class UnaryOperatorTestsData
    {
        public class Calculate : TheoryData<UnaryOperator, Node, decimal>
        {
            public Calculate()
            {
                Add(new MinusUnaryOperator(), new NumberNode(5), -5);
                Add(new MinusUnaryOperator(), new NumberNode(-5), 5);
            }
        }
    }
}
