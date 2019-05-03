using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class ItemGemMapper : ItemMapper<ItemGem>
    {
        public ItemGemMapper()
            : base(ItemCategory.Gem)
        {
        }
    }
}