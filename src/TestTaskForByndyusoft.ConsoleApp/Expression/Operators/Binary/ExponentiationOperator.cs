using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.ConsoleApp.Expression.Operators.Binary
{
    public class ExponentiationOperator : BinaryOperator
    {
        public override char Token => '^';

        public override OperatorPriority Priority => OperatorPriority.First;

        public override decimal Calculate(Node left, Node right)
        {
            return (decimal)Math.Pow((double)left.Calculate(), (double)right.Calculate());
        }
    }
}
