using System.Reflection;
using TestTaskForByndyusoft.Core.Expression.Operators.Binary;
using TestTaskForByndyusoft.Core.Expression.Operators.Unary;
using TestTaskForByndyusoft.Core.Extensions;

namespace TestTaskForByndyusoft.Core.Parser
{
    public class MathematicalExpressionParserSettingsBuilder
    {
        private readonly MathematicalExpressionParserSettings _settings;

        public MathematicalExpressionParserSettingsBuilder()
        {
            _settings = new MathematicalExpressionParserSettings();
        }

        public MathematicalExpressionParserSettingsBuilder RegisterUnaryOperator(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var unaryOperators = assembly.GetOperators<UnaryOperator>();

                _settings.CustomUnaryOperators.AddRange(unaryOperators);
            }

            return this;
        }

        public MathematicalExpressionParserSettingsBuilder RegisterUnaryOperator(params UnaryOperator[] unaryOperators)
        {
            _settings.CustomUnaryOperators.AddRange(unaryOperators);

            return this;
        }

        public MathematicalExpressionParserSettingsBuilder RegisterBinaryOperator(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var binaryOperators = assembly.GetOperators<BinaryOperator>();

                _settings.CustomBinaryOperators.AddRange(binaryOperators);
            }

            return this;
        }

        public MathematicalExpressionParserSettingsBuilder RegisterBinaryOperator(params BinaryOperator[] binaryOperators)
        {
            _settings.CustomBinaryOperators.AddRange(binaryOperators);

            return this;
        }

        public MathematicalExpressionParserSettings Build()
        {
            return _settings;
        }
    }
}
