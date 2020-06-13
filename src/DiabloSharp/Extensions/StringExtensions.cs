namespace DiabloSharp.Extensions
{
    internal static class StringExtensions
    {
        public static string Combine(this string left, string right, string divider)
        {
            if (string.IsNullOrEmpty(left))
                return right;
            if (string.IsNullOrEmpty(right))
                return left;
            return $"{left}{divider}{right}";
        }
    }
}