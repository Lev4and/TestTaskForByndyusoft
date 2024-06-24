namespace TestTaskForByndyusoft.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TokenCharDesignationAttribute : Attribute
    {
        public char Designation { get; }

        public TokenCharDesignationAttribute(char designation)
        {
            Designation = designation;
        }
    }
}
