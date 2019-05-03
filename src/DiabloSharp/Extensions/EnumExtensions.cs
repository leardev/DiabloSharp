using System.Linq;
using DiabloSharp.Attributes;

namespace DiabloSharp.Extensions
{
    public static class EnumExtensions
    {
        public static string ToLocalizationEnUs<TEnum>(this TEnum value)
            where TEnum : struct
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(LocalizationEnUsAttribute), false)
                .Cast<LocalizationEnUsAttribute>()
                .ToList();

            return attributes.Any() ? attributes[0].Text : value.ToString();
        }
    }
}