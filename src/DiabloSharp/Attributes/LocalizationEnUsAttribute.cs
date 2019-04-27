using System;

namespace DiabloSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class LocalizationEnUsAttribute : Attribute
    {
        public string Text { get; }

        public LocalizationEnUsAttribute(string text)
        {
            Text = text;
        }
    }
}