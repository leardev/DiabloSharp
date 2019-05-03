using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal abstract class ItemMapper<TOut> : Mapper<ItemDto, TOut>
        where TOut : Item, new()
    {
        private readonly ItemCategory _itemCategory;

        protected ItemMapper(ItemCategory itemCategory)
        {
            _itemCategory = itemCategory;
        }

        protected override void Map(ItemDto input, TOut output)
        {
            output.Id = new ItemId(input.Slug, input.Id);
            output.Name = input.Name;
            output.IconUrl = input.Icon;
            output.TooltipUrl = input.TooltipParams;
            output.RequiredLevel = input.RequiredLevel;
            output.StackSize = input.StackSizeMax;
            output.AccountBound = input.AccountBound;
            output.Category = _itemCategory;
            output.Quality = EnumConversionHelper.ItemQualityFromString(input.Color);
        }
    }
}