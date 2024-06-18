using TestTaskForByndyusoft.Core.Expression;
using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Parser;

namespace TestTaskForByndyusoft.Core.Tests.Expression
{
    public class MathematicalExpressionTests
    {
        [Theory]
        [ClassData(typeof(MathematicalExpressionTestsData.Calculate))]
        public void Calculate_ShouldReturnExpectedResult(Node root, decimal expectedResult)
        {
            var mathematicalExpression = new MathematicalExpression(root);

            var actual = mathematicalExpression.Calculate();

            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [ClassData(typeof(MathematicalExpressionTestsData.ParseAndCalculate))]
        public void Calculate_ParseExpressionThenCalculate_ShouldReturnExpectedResult(string expression, 
            decimal expectedResult)
        {
            var mathematicalExpression = MathematicalExpressionParser.Parse(expression);

            var actual = mathematicalExpression.Calculate();

            Assert.Equal(expectedResult, actual);
        }
    }
}
