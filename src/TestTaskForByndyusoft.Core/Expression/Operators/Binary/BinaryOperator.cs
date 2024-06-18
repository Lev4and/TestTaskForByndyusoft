using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Binary
{
    public abstract class BinaryOperator : Operator
    {
        public abstract decimal Calculate(Node left, Node right);

        public override string ToString()
        {
            return "BinaryOperator";
        }
    }
}
