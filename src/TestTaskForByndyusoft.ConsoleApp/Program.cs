using TestTaskForByndyusoft.Core.Expression;
using TestTaskForByndyusoft.Core.Parser;

while (true)
{
    try
    {
        var expression = GetMathematicalExpression();
        var parsedExpression = ParseMathematicalExpression(expression);
        var calculatedResult = CalculateMathematicalExpression(parsedExpression);

        OutputCalculatedResult(calculatedResult);
    }
    catch (Exception exception)
    {
        OutputErrorInformation(exception);
    }
}

static string GetMathematicalExpression()
{
    OutputString("Enter a mathematical expression: ");

    return InputString();
}

static MathematicalExpression ParseMathematicalExpression(string expression)
{
    return MathematicalExpressionParser.Parse(expression);
}

static decimal CalculateMathematicalExpression(MathematicalExpression mathematicalExpression)
{
    return mathematicalExpression.Calculate();
}

static void OutputCalculatedResult(decimal result)
{
    OutputString($"Result: {result}\n");
}

static void OutputErrorInformation(Exception exception)
{
    OutputString($"An error has occurred: {exception.Message}\n");
}

static string InputString()
{
    return Console.ReadLine() ?? string.Empty;
}

static void OutputString(string value)
{
    Console.Write(value);
}
