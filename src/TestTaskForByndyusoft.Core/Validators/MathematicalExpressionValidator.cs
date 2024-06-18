using TestTaskForByndyusoft.Core.Exceptions;

namespace TestTaskForByndyusoft.Core.Validators
{
    public class MathematicalExpressionValidator
    {
        public void Validate(string expression)
        {
            if (string.IsNullOrEmpty(expression) || string.IsNullOrWhiteSpace(expression))
            {
                throw new MathematicalExpressionSyntaxException("The expression should be not empty");
            }
        }
    }
}
