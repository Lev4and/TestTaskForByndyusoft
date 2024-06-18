using TestTaskForByndyusoft.Core.Exceptions;
using TestTaskForByndyusoft.Core.Validators;

namespace TestTaskForByndyusoft.Core.Tests.Validators
{
    public class MathematicalExpressionValidatorTests
    {
        private readonly MathematicalExpressionValidator _validator;

        public MathematicalExpressionValidatorTests()
        {
            _validator = new MathematicalExpressionValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData(null)]
        public void Validate_WithInvalidParam_ShouldThrowException(string expression)
        {
            var action = () => _validator.Validate(expression);

            Assert.Throws<MathematicalExpressionSyntaxException>(action);
        }

        [Theory]
        [InlineData("1+2-3")]
        public void Validate_WithValidParam_ShouldNotThrowException(string expression)
        {
            _validator.Validate(expression);
        }
    }
}
