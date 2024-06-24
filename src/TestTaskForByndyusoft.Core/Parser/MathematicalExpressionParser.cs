using System.Linq;
using TestTaskForByndyusoft.Core.Exceptions;
using TestTaskForByndyusoft.Core.Expression;
using TestTaskForByndyusoft.Core.Expression.Nodes;
using TestTaskForByndyusoft.Core.Expression.Operators;
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

        private readonly List<UnaryOperator> _unaryOperators;
        private readonly List<BinaryOperator> _binaryOperators;

        private readonly List<OperatorPriority> _operatorPriorities;

        public MathematicalExpressionParser(string expression)
        {
            _validator = new MathematicalExpressionValidator();
            _formatter = new MathematicalExpressionFormatter();

            _validator.Validate(expression);

            var formattedExpression = _formatter.Format(expression);

            _tokenizer = new Tokenizer(formattedExpression);

            _unaryOperators = FindOperators<UnaryOperator>();
            _binaryOperators = FindOperators<BinaryOperator>();

            _operatorPriorities = Enum.GetValues<OperatorPriority>()
                .OrderByDescending(operatorPriority => operatorPriority)
                .ToList();
        }

        public static MathematicalExpression Parse(string expression)
        {
            var parser = new MathematicalExpressionParser(expression);

            return parser.Parse();
        }

        public MathematicalExpression Parse()
        {
            var rootNode = ParseRootNode();

            return new MathematicalExpression(rootNode);
        }

        private Node ParseRootNode()
        {
            return ParseBinaryNode(_operatorPriorities.First());
        }

        private Node ParseBinaryNode(OperatorPriority operatorPriority)
        {
            var operatorPriorityIndex = _operatorPriorities.IndexOf(operatorPriority);
            var hasPriorityOperatorPriority = operatorPriorityIndex != _operatorPriorities.Count - 1;

            var left = hasPriorityOperatorPriority
                ? ParseBinaryNode(_operatorPriorities.ElementAt(operatorPriorityIndex + 1)) 
                : ParseUnaryNode();

            while (true)
            {
                var binaryOperator = _binaryOperators
                    .FirstOrDefault(binaryOperator => binaryOperator.Token == _tokenizer.CurrentToken &&
                        binaryOperator.Priority == operatorPriority);

                if (binaryOperator is null)
                {
                    return left;
                }

                _tokenizer.NextToken();

                var right = hasPriorityOperatorPriority
                    ? ParseBinaryNode(_operatorPriorities.ElementAt(operatorPriorityIndex + 1))
                    : ParseUnaryNode();

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

                var unaryOperator = _unaryOperators
                    .FirstOrDefault(unaryOperator => unaryOperator.Token == _tokenizer.CurrentToken);

                if (unaryOperator is not null)
                {
                    _tokenizer.NextToken();

                    var right = ParseUnaryNode();

                    return new UnaryNode(right, unaryOperator);
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

                var node = ParseBinaryNode(_operatorPriorities.First());

                if (_tokenizer.CurrentToken != Token.CloseParens)
                {
                    throw new MathematicalExpressionSyntaxException("Missing close parenthesis");
                }

                _tokenizer.NextToken();

                return node;
            }

            throw new MathematicalExpressionSyntaxException($"Unexpect token: {_tokenizer.CurrentNumber}");
        }

        private List<T> FindOperators<T>() 
            where T : Operator
        {
            var operators = new List<T>();

            var operatorTypes = typeof(MathematicalExpressionParser).Assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(T)))
                .ToList();

            foreach (var operatorType in operatorTypes)
            {
                var instance = Activator.CreateInstance(operatorType);

                if (instance is not null)
                {
                    operators.Add((T)instance);
                }
            }

            return operators;
        }
    }
}
