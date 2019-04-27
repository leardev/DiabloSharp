using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemLegendaryPotionConverter : ItemConverter<ItemLegendaryPotion>
    {
        public ItemLegendaryPotionConverter() : base(ItemCategory.LegendaryPotion)
        {
        }
    }
}