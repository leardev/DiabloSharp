using System.Text;

namespace DiabloSharp.Extensions
{
    internal static class StringBuilderExtensions
    {
        public static void AppendProperty(this StringBuilder stringBuilder, string name, string value)
        {
            stringBuilder.Append($"{name} = {{{value}}}, ");
        }
    }
}