using System.Reflection;
using TestTaskForByndyusoft.Core.Expression.Operators;

namespace TestTaskForByndyusoft.Core.Extensions
{
    public static class AssemblyExtensions
    {
        public static List<TOperator> GetOperators<TOperator>(this Assembly assembly)
            where TOperator : Operator
        {
            var operators = new List<TOperator>();

            var operatorTypes = assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(TOperator)))
                .ToList();

            foreach (var operatorType in operatorTypes)
            {
                var instance = Activator.CreateInstance(operatorType);

                if (instance is not null)
                {
                    operators.Add((TOperator)instance);
                }
            }

            return operators;
        }
    }
}
