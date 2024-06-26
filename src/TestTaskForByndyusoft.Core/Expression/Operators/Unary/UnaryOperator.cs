﻿using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Unary
{
    public abstract class UnaryOperator : Operator
    {
        public abstract decimal Calculate(Node node);

        public override string ToString()
        {
            return "UnaryOperator";
        }
    }
}
