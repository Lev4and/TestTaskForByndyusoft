using TestTaskForByndyusoft.Core.Expression;
using TestTaskForByndyusoft.Core.Parser;

var builder = new MathematicalExpressionParserSettingsBuilder();

var settings = builder.RegisterUnaryOperator(typeof(Program).Assembly)
    .RegisterBinaryOperator(typeof(Program).Assembly)
    .Build();

while (true)
{
    try
    {
        var expression = GetMathematicalExpression();

        var parsedExpression = ParseMathematicalExpression(expression, settings);
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

static MathematicalExpression ParseMathematicalExpression(string expression, 
    MathematicalExpressionParserSettings settings)
{
    return MathematicalExpressionParser.Parse(expression, settings);
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
