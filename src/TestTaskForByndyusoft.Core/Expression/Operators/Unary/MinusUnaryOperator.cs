using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Unary
{
    public class MinusUnaryOperator : UnaryOperator
    {
        public override decimal Calculate(Node node)
        {
            return - node.Calculate();
        }

        public override string ToString()
        {
            return "MinusUnaryOperator";
        }
    }
}
