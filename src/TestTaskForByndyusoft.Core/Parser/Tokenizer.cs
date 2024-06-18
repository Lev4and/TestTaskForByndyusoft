using System.Globalization;
using System.Text;

namespace TestTaskForByndyusoft.Core.Parser
{
    public class Tokenizer
    {
        private const char EndOfExpression = '\0';

        private readonly IEnumerator<char> _expressionEnumerator;
        private readonly IDictionary<char, Token> _tokensDictionary =
            new Dictionary<char, Token>()
            {
                { '+', Token.Add },
                { '-', Token.Subtract },
                { '*', Token.Multiply },
                { '/', Token.Divide },
                { '(', Token.OpenParens },
                { ')', Token.CloseParens },
            };

        private char _currentChar;
        private Token _currentToken;
        private decimal _currentNumber;

        public Token CurrentToken => _currentToken;

        public decimal CurrentNumber => _currentNumber;

        public Tokenizer(string expression)
        {
            _expressionEnumerator = expression.GetEnumerator();
            _expressionEnumerator.MoveNext();

            _currentChar = _expressionEnumerator.Current;

            NextToken();
        }

        public void NextToken()
        {
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }

            if (_currentChar == EndOfExpression)
            {
                _currentToken = Token.EndOfExpression;

                return;
            }

            if (_tokensDictionary.ContainsKey(_currentChar))
            {
                _currentToken = _tokensDictionary[_currentChar];

                NextChar();

                return;
            }

            if (char.IsDigit(_currentChar) || _currentChar == '.')
            {
                var hasDecimalPoint = false;
                var stringBuilder = new StringBuilder();

                while (char.IsDigit(_currentChar) || !hasDecimalPoint && _currentChar == '.')
                {
                    stringBuilder.Append(_currentChar);

                    hasDecimalPoint = _currentChar == '.';

                    NextChar();
                }

                _currentNumber = decimal.Parse(stringBuilder.ToString(), CultureInfo.InvariantCulture);
                _currentToken = Token.Number;

                return;
            }
        }

        private void NextChar()
        {
            var isMoved = _expressionEnumerator.MoveNext();

            _currentChar = isMoved
                ? _expressionEnumerator.Current
                : EndOfExpression;
        }
    }
}
