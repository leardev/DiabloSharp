using DiabloSharp.Attributes;

namespace DiabloSharp.Models
{
    public enum ItemCategory
    {
        [LocalizationEnUs("Equipment")]
        Equipment,
        [LocalizationEnUs("Follower Token")]
        FollowerToken,
        [LocalizationEnUs("Gem")]
        Gem,
        [LocalizationEnUs("Legendary Gem")]
        LegendaryGem,
        [LocalizationEnUs("Legendary Potion")]
        LegendaryPotion
    }
}