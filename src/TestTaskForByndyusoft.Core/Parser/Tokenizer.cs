using System.Globalization;
using System.Text;
using TestTaskForByndyusoft.Core.Constants;

namespace TestTaskForByndyusoft.Core.Parser
{
    public class Tokenizer
    {
        private readonly IEnumerator<char> _expressionEnumerator;

        private char _currentChar;
        private char _currentToken;
        private decimal _currentNumber;
        private TokenType _currentTokenType;

        public char CurrentToken => _currentToken;

        public decimal CurrentNumber => _currentNumber;

        public TokenType CurrentTokenType => _currentTokenType;

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

            if (_currentChar == TokenConstants.EndOfExpression)
            {
                _currentTokenType = TokenType.EndOfExpression;
                _currentToken = TokenConstants.EndOfExpression;

                return;
            }

            if (!char.IsDigit(_currentChar) || _currentChar == TokenConstants.OpenParens || 
                _currentChar == TokenConstants.CloseParens)
            {
                _currentToken = _currentChar;

                if (char.IsSymbol(_currentChar)) _currentTokenType = TokenType.Symbol;
                else if (_currentChar == TokenConstants.OpenParens) _currentTokenType = TokenType.OpenParens;
                else _currentTokenType = TokenType.CloseParens;

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
                
                _currentToken = '\0';
                _currentTokenType = TokenType.Number;

                return;
            }
        }

        private void NextChar()
        {
            var isMoved = _expressionEnumerator.MoveNext();

            _currentChar = isMoved
                ? _expressionEnumerator.Current
                : TokenConstants.EndOfExpression;
        }
    }
}
