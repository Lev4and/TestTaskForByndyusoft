using TestTaskForByndyusoft.Core.Expression.Operators.Binary;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;
using TestTaskForByndyusoft.Core.Extensions;

namespace TestTaskForByndyusoft.Core.Parser
{
    public class MathematicalExpressionParserSettings
    {
        public List<UnaryOperator> CustomUnaryOperators { get; } = new List<UnaryOperator>();

        public List<BinaryOperator> CustomBinaryOperators { get; } = new List<BinaryOperator>();
    }
}
