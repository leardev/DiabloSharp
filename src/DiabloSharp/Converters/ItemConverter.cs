using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal abstract class ItemConverter<T> where T : Item, new()
    {
        private readonly ItemCategory _itemCategory;

        protected ItemConverter(ItemCategory itemCategory)
        {
            _itemCategory = itemCategory;
        }

        public virtual T ItemToModel(ItemDto itemDto)
        {
            return new T
            {
                Id = new ItemIdentifier(itemDto.Slug, itemDto.Id),
                Name = itemDto.Name,
                IconUrl = itemDto.Icon,
                TooltipUrl = itemDto.TooltipParams,
                RequiredLevel = itemDto.RequiredLevel,
                StackSize = itemDto.StackSizeMax,
                AccountBound = itemDto.AccountBound,
                Category = _itemCategory,
                Quality = EnumConversionHelper.ItemQualityFromString(itemDto.Color)
            };
        }

        public List<T> ItemsToModel(IEnumerable<ItemDto> itemDtos)
        {
            var items = new List<T>();
            foreach (var itemDto in itemDtos)
            {
                var item = ItemToModel(itemDto);
                items.Add(item);
            }

            return items;
        }
    }
}