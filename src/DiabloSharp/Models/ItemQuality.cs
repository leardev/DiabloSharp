using DiabloSharp.Attributes;

namespace DiabloSharp.Models
{
    public enum ItemQuality
    {
        [LocalizationEnUs("Normal")]
        Normal,
        [LocalizationEnUs("Magic")]
        Magic,
        [LocalizationEnUs("Rare")]
        Rare,
        [LocalizationEnUs("Legendary")]
        Legendary,
        [LocalizationEnUs("Set")]
        Set
    }
}