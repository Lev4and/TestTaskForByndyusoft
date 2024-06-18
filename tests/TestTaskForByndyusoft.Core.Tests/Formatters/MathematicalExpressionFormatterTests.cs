using TestTaskForByndyusoft.Core.Exceptions;
using TestTaskForByndyusoft.Core.Formatters;

namespace TestTaskForByndyusoft.Core.Tests.Formatters
{
    public class MathematicalExpressionFormatterTests
    {
        private readonly MathematicalExpressionFormatter _formatter;

        public MathematicalExpressionFormatterTests()
        {
            _formatter = new MathematicalExpressionFormatter();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData(null)]
        public void Format_WithInvalidParam_ShouldThrowException(string expression)
        {
            var action = () => _formatter.Format(expression);

            Assert.Throws<MathematicalExpressionSyntaxException>(action);
        }

        [Theory]
        [InlineData("1 + 2 - 3", "1+2-3")]
        [InlineData("(5 * 10 / 5 + 10) + ((35 - 10 + 5 * 5) / 5) + 25 - 15", "(5*10/5+10)+((35-10+5*5)/5)+25-15")]
        public void Format_WithValidParam_ShouldReturnExpectedResult(string expression, string expectedResult)
        {
            var actual = _formatter.Format(expression);

            Assert.Equal(expectedResult, actual);
        }
    }
}
