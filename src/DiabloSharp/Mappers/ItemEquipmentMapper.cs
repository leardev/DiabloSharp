using System;
using System.Collections.Generic;
using System.Linq;
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
            output.Cube = MapCube(output.Id, output.Slots.First());
        }

        private IEnumerable<ItemEquipmentSlot> MapSlots(ItemDto input)
        {
            var outputs = new List<ItemEquipmentSlot>();
            foreach (var inputSlot in input.Slots)
            {
                if (!EnumConversionHelper.TryItemEquipmentSlotFromString(inputSlot, out var slot) ||
                    input.Type.TwoHanded && slot == ItemEquipmentSlot.Offhand)
                    continue;
                outputs.Add(slot);
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

        private ItemEquipmentCube MapCube(ItemId itemId, ItemEquipmentSlot slot)
        {
            if (!CubeHelper.IsCube(itemId))
                return ItemEquipmentCube.None;
            switch (slot)
            {
                case ItemEquipmentSlot.Head:
                case ItemEquipmentSlot.Shoulders:
                case ItemEquipmentSlot.Hands:
                case ItemEquipmentSlot.Wrists:
                case ItemEquipmentSlot.Waist:
                case ItemEquipmentSlot.Legs:
                case ItemEquipmentSlot.Feet:
                case ItemEquipmentSlot.Torso:
                    return ItemEquipmentCube.Armor;
                case ItemEquipmentSlot.Neck:
                case ItemEquipmentSlot.LeftFinger:
                case ItemEquipmentSlot.RightFinger:
                    return ItemEquipmentCube.Jewelery;
                case ItemEquipmentSlot.Mainhand:
                case ItemEquipmentSlot.Offhand:
                    return ItemEquipmentCube.Weapon;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}