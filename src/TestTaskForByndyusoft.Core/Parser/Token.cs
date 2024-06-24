using TestTaskForByndyusoft.Core.Attributes;

namespace TestTaskForByndyusoft.Core.Parser
{
    public enum Token
    {
        EndOfExpression,
        [TokenCharDesignation('+')]
        Add,
        [TokenCharDesignation('-')]
        Subtract,
        [TokenCharDesignation('*')]
        Multiply,
        [TokenCharDesignation('/')]
        Divide,
        [TokenCharDesignation('(')]
        OpenParens,
        [TokenCharDesignation(')')]
        CloseParens,
        Number,
    }
}
