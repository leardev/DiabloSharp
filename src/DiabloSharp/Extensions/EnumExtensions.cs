using System.ComponentModel;
using System.Linq;

namespace DiabloSharp.Extensions
{
    internal static class EnumExtensions
    {
        public static string ToDescription<TEnum>(this TEnum value) where TEnum : struct
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .ToList();

            return attributes.Any() ? attributes[0].Description : value.ToString();
        }
    }
}