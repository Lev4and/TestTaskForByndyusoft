using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Parser;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Binary
{
    public class DivideOperator : BinaryOperator
    {
        public override Token Token => Token.Divide;

        public override OperatorPriority Priority => OperatorPriority.First;

        public override decimal Calculate(Node left, Node right)
        {
            return left.Calculate() / right.Calculate();
        }

        public override string ToString()
        {
            return "DivideOperator";
        }
    }
}
