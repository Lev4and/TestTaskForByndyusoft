using TestTaskForByndyusoft.Core.Expression.Operators.Unary;

namespace TestTaskForByndyusoft.Core.Expression.Nodes
{
    public class UnaryNode : Node
    {
        private readonly Node _node;
        private readonly UnaryOperator _unaryOperator;

        public UnaryNode(Node node, UnaryOperator unaryOperator)
        {
            _node = node;
            _unaryOperator = unaryOperator;
        }

        public override decimal Calculate()
        {
            return _unaryOperator.Calculate(_node);
        }

        public override string ToString()
        {
            return $"UnaryNode ({_node.ToString()}) & ({_unaryOperator.ToString()})";
        }
    }
}
