using TestTaskForByndyusoft.Core.Parser;

namespace TestTaskForByndyusoft.Core.Expression.Operators
{
    public abstract class Operator
    {
        public abstract char Token { get; }

        public abstract OperatorPriority Priority { get; }

        public override string ToString()
        {
            return "Operator";
        }
    }
}
