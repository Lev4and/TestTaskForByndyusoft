using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Unary
{
    public class MinusUnaryOperatorTestsData
    {
        public class Calculate : TheoryData<Node, decimal>
        {
            public Calculate()
            {
                Add(new NumberNode(5), -5);
                Add(new NumberNode(-5), 5);
            }
        }
    }
}
