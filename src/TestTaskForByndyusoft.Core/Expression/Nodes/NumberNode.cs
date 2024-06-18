namespace TestTaskForByndyusoft.Core.Expression.Nodes
{
    public class NumberNode : Node
    {
        private readonly decimal _value;

        public NumberNode(decimal value)
        {
            _value = value;
        }

        public override decimal Calculate()
        {
            return _value;
        }

        public override string ToString()
        {
            return $"NumberNode ({_value})";
        }
    }
}
