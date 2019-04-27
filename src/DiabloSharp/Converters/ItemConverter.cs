using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal abstract class ItemConverter<T> where T : Item, new()
    {
        private readonly ItemCategory _itemCategory;

        private readonly Dictionary<string, ItemQuality> _qualityByText;

        protected ItemConverter(ItemCategory itemCategory)
        {
            _itemCategory = itemCategory;
            _qualityByText = new Dictionary<string, ItemQuality>
            {
                { "white", ItemQuality.Normal },
                { "blue", ItemQuality.Magic },
                { "yellow", ItemQuality.Rare },
                { "orange", ItemQuality.Legendary },
                { "green", ItemQuality.Set }
            };
        }

        public virtual T ItemToModel(ItemDto itemDto)
        {
            return new T
            {
                Id = new ItemIdentifier(itemDto.Id, itemDto.Slug),
                Name = itemDto.Name,
                IconUrl = itemDto.Icon,
                TooltipUrl = itemDto.TooltipParams,
                RequiredLevel = itemDto.RequiredLevel,
                StackSize = itemDto.StackSizeMax,
                AccountBound = itemDto.AccountBound,
                Category = _itemCategory,
                Quality = _qualityByText[itemDto.Color]
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