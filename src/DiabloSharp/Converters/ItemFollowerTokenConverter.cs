using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemFollowerTokenConverter : ItemConverter<ItemFollowerToken>
    {
        private readonly Dictionary<string, ItemFollowerTokenKind> _itemFollowerTokenKindByTypeId;

        public ItemFollowerTokenConverter() : base(ItemCategory.FollowerToken)
        {
            _itemFollowerTokenKindByTypeId = new Dictionary<string, ItemFollowerTokenKind>
            {
                { "EnchantressSpecial", ItemFollowerTokenKind.EnchantressFocus },
                { "ScoundrelSpecial", ItemFollowerTokenKind.ScoundrelToken },
                { "TemplarSpecial", ItemFollowerTokenKind.TemplarRelic },
            };
        }

        public override ItemFollowerToken ItemToModel(ItemDto itemDto)
        {
            var item = base.ItemToModel(itemDto);
            item.Kind = _itemFollowerTokenKindByTypeId[itemDto.Type.Id];
            return item;
        }
    }
}