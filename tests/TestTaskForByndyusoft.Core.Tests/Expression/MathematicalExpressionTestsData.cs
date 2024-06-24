using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression
{
    public class MathematicalExpressionTestsData
    {
        public class Calculate : TheoryData<Node, decimal>
        {
            public Calculate()
            {
                Add(new BinaryNode(new BinaryNode(new NumberNode(1), new NumberNode(2), new AddOperator()),
                    new NumberNode(3), new SubtractOperator()), 0);

                Add(new BinaryNode(new BinaryNode(new NumberNode(2), new NumberNode(2), new MultiplyOperator()),
                    new NumberNode(2), new AddOperator()), 6);
            }
        }

        public class ParseAndCalculate : TheoryData<string, decimal>
        {
            public ParseAndCalculate()
            {
                Add("+ 5 - 3", 2);
                Add("- 5 + 3", -2);
                Add("1 + 2 - 3", 0);
                Add("(5 * 10 / 5 + 10) + ((35 - 10 + 5 * 5) / 5) + 25 - 15", 40);
            }
        }
    }
}
