using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class ItemFollowerTokenMapper : ItemMapper<ItemFollowerToken>
    {
        public ItemFollowerTokenMapper() : base(ItemCategory.FollowerToken)
        {
        }

        protected override void Map(ItemDto input, ItemFollowerToken output)
        {
            base.Map(input, output);
            output.Kind = EnumConversionHelper.ItemFollowerTokenKindFromString(input.Type.Id);
        }
    }
}