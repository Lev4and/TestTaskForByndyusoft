using TestTaskForByndyusoft.Core.Exceptions;

namespace TestTaskForByndyusoft.Core.Formatters
{
    public class MathematicalExpressionFormatter
    {
        public string Format(string expression)
        {
            if (string.IsNullOrEmpty(expression) || string.IsNullOrWhiteSpace(expression))
            {
                throw new MathematicalExpressionSyntaxException("The expression should be not empty");
            }

            return expression.Replace(" ", "").Replace("\t", "").Replace("\n", "");
        }
    }
}
