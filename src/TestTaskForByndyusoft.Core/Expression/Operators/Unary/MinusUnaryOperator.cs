using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Parser;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Unary
{
    public class MinusUnaryOperator : UnaryOperator
    {
        public override char Token => '-';

        public override OperatorPriority Priority => OperatorPriority.Second;

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
