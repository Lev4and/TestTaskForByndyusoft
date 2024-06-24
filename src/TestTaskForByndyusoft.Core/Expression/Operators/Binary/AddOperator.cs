using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Parser;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Binary
{
    public class AddOperator : BinaryOperator
    {
        public override Token Token => Token.Add;

        public override OperatorPriority Priority => OperatorPriority.Second;

        public override decimal Calculate(Node left, Node right)
        {
            return left.Calculate() + right.Calculate();
        }

        public override string ToString()
        {
            return "AddOperator";
        }
    }
}
