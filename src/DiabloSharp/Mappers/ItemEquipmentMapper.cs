using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class ItemEquipmentMapper : ItemMapper<ItemEquipment>
    {
        public ItemEquipmentMapper()
            : base(ItemCategory.Equipment)
        {
        }

        protected override void Map(ItemDto input, ItemEquipment output)
        {
            base.Map(input, output);
            output.Kind = EnumConversionHelper.ItemEquipmentKindFromString(input.Type.Id);
            output.Slots = MapSlots(input);
            output.Characters = EnumConversionHelper.CharacterIdentifiersFromString(input.Type.Id);
            output.IsTwoHanded = input.Type.TwoHanded;
            output.Set = MapSet(input);
        }

        private IEnumerable<ItemEquipmentSlot> MapSlots(ItemDto input)
        {
            var outputs = new List<ItemEquipmentSlot>();
            foreach (var slot in input.Slots)
            {
                var x = EnumConversionHelper.ItemEquipmentSlotFromString(slot);
                if (!x.HasValue || input.Type.TwoHanded && x == ItemEquipmentSlot.Offhand)
                    continue;
                outputs.Add(x.Value);
            }

            return outputs;
        }

        private ItemEquipmentSet MapSet(ItemDto input)
        {
            return new ItemEquipmentSet
            {
                Name = input.SetName,
                ItemIds = MapItemPaths(input.SetItems)
            };
        }

        private IEnumerable<ItemId> MapItemPaths(IEnumerable<string> inputs)
        {
            var outputs = new List<ItemId>();
            foreach (var input in inputs)
            {
                var output = ItemIdentifierHelper.FromString(input);
                outputs.Add(output);
            }
            return outputs;
        }
    }
}