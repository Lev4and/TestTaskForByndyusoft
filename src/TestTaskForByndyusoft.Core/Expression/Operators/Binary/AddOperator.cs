﻿using TestTaskForByndyusoft.Core.Expression.Nodes;

namespace TestTaskForByndyusoft.Core.Expression.Operators.Binary
{
    public class AddOperator : BinaryOperator
    {
        public override decimal Calculate(Node left, Node right)
        {
            return left.Calculate() + right.Calculate();
        }

        public override string ToString()
        {
            return "AddOperator";
        }
    }
}