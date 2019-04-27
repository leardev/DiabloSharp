using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemFollowerTokenConverter : ItemConverter<ItemFollowerToken>
    {
        public ItemFollowerTokenConverter() : base(ItemCategory.FollowerToken)
        {
        }

        public override ItemFollowerToken ItemToModel(ItemDto itemDto)
        {
            var item = base.ItemToModel(itemDto);
            item.Kind = EnumConversionHelper.ItemFollowerTokenKindFromString(itemDto.Type.Id);
            return item;
        }
    }
}