using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Expression.Nodes
{
    public class BinaryNode : Node
    {
        private readonly Node _left;
        private readonly Node _right;
        private readonly BinaryOperator _binaryOperator;

        public BinaryNode(Node left, Node right, BinaryOperator binaryOperator)
        {
            _left = left;
            _right = right;
            _binaryOperator = binaryOperator;
        }

        public override decimal Calculate()
        {
            return _binaryOperator.Calculate(_left, _right);
        }

        public override string ToString()
        {
            return $"BinaryNode ({_left.ToString()})_({_right.ToString()}) & ({_binaryOperator.ToString()})";
        }
    }
}
