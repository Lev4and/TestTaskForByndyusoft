using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;

namespace TestTaskForByndyusoft.Core.Tests.Expression.Operators.Binary
{
    public class BinaryOperatorTestsData
    {
        public class Calculate : TheoryData<BinaryOperator, Node, Node, decimal>
        {
            public Calculate()
            {
                Add(new AddOperator(), new NumberNode(0), new NumberNode(0), 0);
                Add(new AddOperator(), new NumberNode(5), new NumberNode(2), 7);
                Add(new AddOperator(), new NumberNode(2), new NumberNode(5), 7);
                Add(new AddOperator(), new NumberNode(2), new NumberNode(2.2m), 4.2m);
                Add(new AddOperator(), new NumberNode(-5), new NumberNode(10), 5);
                Add(new AddOperator(), new NumberNode(-5), new NumberNode(-10), -15);

                Add(new DivideOperator(), new NumberNode(4), new NumberNode(2), 2);
                Add(new DivideOperator(), new NumberNode(10), new NumberNode(2), 5);
                Add(new DivideOperator(), new NumberNode(6), new NumberNode(4), 1.5m);
                Add(new DivideOperator(), new NumberNode(10), new NumberNode(0.5m), 20);
                Add(new DivideOperator(), new NumberNode(-10), new NumberNode(0.5m), -20);
                Add(new DivideOperator(), new NumberNode(-10), new NumberNode(-0.5m), 20);

                Add(new MultiplyOperator(), new NumberNode(4), new NumberNode(0), 0);
                Add(new MultiplyOperator(), new NumberNode(4), new NumberNode(2), 8);
                Add(new MultiplyOperator(), new NumberNode(4), new NumberNode(0.5m), 2);
                Add(new MultiplyOperator(), new NumberNode(4), new NumberNode(1.5m), 6);
                Add(new MultiplyOperator(), new NumberNode(-4), new NumberNode(1.5m), -6);
                Add(new MultiplyOperator(), new NumberNode(-4), new NumberNode(-1.5m), 6);

                Add(new SubtractOperator(), new NumberNode(4), new NumberNode(0), 4);
                Add(new SubtractOperator(), new NumberNode(4), new NumberNode(2), 2);
                Add(new SubtractOperator(), new NumberNode(2), new NumberNode(4), -2);
                Add(new SubtractOperator(), new NumberNode(-2), new NumberNode(4), -6);
                Add(new SubtractOperator(), new NumberNode(-2), new NumberNode(-4), 2);
                Add(new SubtractOperator(), new NumberNode(-6), new NumberNode(-3.5m), -2.5m);
            }
        }
    }
}
