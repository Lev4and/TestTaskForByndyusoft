using TestTaskForByndyusoft.Core.Exceptions;
using TestTaskForByndyusoft.Core.Expression;
using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;
using TestTaskForByndyusoft.Core.Formatters;
using TestTaskForByndyusoft.Core.Validators;

namespace TestTaskForByndyusoft.Core.Parser
{
    public class MathematicalExpressionParser
    {
        private readonly Tokenizer _tokenizer;

        private readonly MathematicalExpressionValidator _validator;
        private readonly MathematicalExpressionFormatter _formatter;

        public MathematicalExpressionParser(string expression)
        {
            _validator = new MathematicalExpressionValidator();
            _formatter = new MathematicalExpressionFormatter();

            _validator.Validate(expression);

            var formattedExpression = _formatter.Format(expression);

            _tokenizer = new Tokenizer(formattedExpression);

        }

        public static MathematicalExpression Parse(string expression)
        {
            var parser = new MathematicalExpressionParser(expression);

            return parser.Parse();
        }

        public MathematicalExpression Parse()
        {
            var rootNode = ParseAddSubtractNode();

            return new MathematicalExpression(rootNode);
        }

        private Node ParseAddSubtractNode()
        {
            var left = ParseMultiplyDivideNode();

            while (true)
            {
                var binaryOperator = null as BinaryOperator;

                if (_tokenizer.CurrentToken == Token.Add)
                {
                    binaryOperator = new AddOperator();
                }
                else if (_tokenizer.CurrentToken == Token.Subtract)
                {
                    binaryOperator = new SubtractOperator();
                }

                if (binaryOperator is null)
                {
                    return left;
                }

                _tokenizer.NextToken();

                var right = ParseMultiplyDivideNode();

                left = new BinaryNode(left, right, binaryOperator);
            }
        }

        private Node ParseMultiplyDivideNode()
        {
            var left = ParseUnaryNode();

            while (true)
            {
                var binaryOperator = null as BinaryOperator;

                if (_tokenizer.CurrentToken == Token.Multiply)
                {
                    binaryOperator = new MultiplyOperator();
                }
                else if (_tokenizer.CurrentToken == Token.Divide)
                {
                    binaryOperator = new DivideOperator();
                }

                if (binaryOperator is null)
                {
                    return left;
                }

                _tokenizer.NextToken();

                var right = ParseUnaryNode();

                left = new BinaryNode(left, right, binaryOperator);
            }
        }


        private Node ParseUnaryNode()
        {
            while (true)
            {
                if (_tokenizer.CurrentToken == Token.Add)
                {
                    _tokenizer.NextToken();

                    continue;
                }

                if (_tokenizer.CurrentToken == Token.Subtract)
                {
                    _tokenizer.NextToken();

                    var right = ParseUnaryNode();

                    return new UnaryNode(right, new MinusUnaryOperator());
                }

                return ParseLeafNode();
            }
        }

        private Node ParseLeafNode()
        {
            if (_tokenizer.CurrentToken == Token.Number)
            {
                var node = new NumberNode(_tokenizer.CurrentNumber);

                _tokenizer.NextToken();

                return node;
            }

            if (_tokenizer.CurrentToken == Token.OpenParens)
            {
                _tokenizer.NextToken();

                var node = ParseAddSubtractNode();

                if (_tokenizer.CurrentToken != Token.CloseParens)
                {
                    throw new MathematicalExpressionSyntaxException("Missing close parenthesis");
                }

                _tokenizer.NextToken();

                return node;
            }

            throw new MathematicalExpressionSyntaxException($"Unexpect token: {_tokenizer.CurrentNumber}");
        }
    }
}
