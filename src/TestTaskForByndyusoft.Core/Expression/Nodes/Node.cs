namespace TestTaskForByndyusoft.Core.Expression.Nodes
{
    public abstract class Node
    {
        public abstract decimal Calculate();

        public override string ToString()
        {
            return $"Node";
        }
    }
}
