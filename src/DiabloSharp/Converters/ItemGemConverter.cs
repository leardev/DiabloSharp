using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemGemConverter : ItemConverter<ItemGem>
    {
        public ItemGemConverter() : base(ItemCategory.Gem)
        {
        }
    }
}