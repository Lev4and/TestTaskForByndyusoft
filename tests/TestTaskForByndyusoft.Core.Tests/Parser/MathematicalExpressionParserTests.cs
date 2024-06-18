using TestTaskForByndyusoft.Core.Exceptions;
using TestTaskForByndyusoft.Core.Parser;

namespace TestTaskForByndyusoft.Core.Tests.Parser
{
    public class MathematicalExpressionParserTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("()")]
        [InlineData("1 + 2 - ")]
        public void Parse_WithInvalidParam_ShouldThrowExpection(string expression)
        {
            var action = () => MathematicalExpressionParser.Parse(expression);

            Assert.Throws<MathematicalExpressionSyntaxException>(action);
        }

        [Theory]
        [InlineData("1 + 2 - 3")]
        [InlineData("(5 * 10 / 5 + 10) + ((35 - 10 + 5 * 5) / 5) + 25 - 15")]
        public void Parse_WithValidParam_ShouldReturnNotNullResult(string expression)
        {
            var mathematicalExpression = MathematicalExpressionParser.Parse(expression);

            Assert.NotNull(mathematicalExpression);
        }
    }
}
