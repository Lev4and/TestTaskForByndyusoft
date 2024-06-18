using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Expression
{
    public class MathematicalExpression
    {
        private readonly Node _root;

        public MathematicalExpression(Node root)
        {
            _root = root;
        }

        public decimal Calculate()
        {
            return _root.Calculate();
        }
    }
}
