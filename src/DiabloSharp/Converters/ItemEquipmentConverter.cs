using System;
using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemEquipmentConverter : ItemConverter<ItemEquipment>
    {
        public ItemEquipmentConverter() : base(ItemCategory.Equipment)
        {
        }

        public override ItemEquipment ItemToModel(ItemDto itemDto)
        {
            var item = base.ItemToModel(itemDto);
            item.Kind = EnumConversionHelper.ItemEquipmentKindFromString(itemDto.Type.Id);
            item.Slots = SlotsToModel(itemDto);
            item.Classes = EnumConversionHelper.CharacterClassIdentifiersFromItemTypeId(itemDto.Type.Id);
            item.IsTwoHanded = itemDto.Type.TwoHanded;
            item.Set = SetToModel(itemDto);
            return item;
        }

        private ItemEquipmentSet SetToModel(ItemDto itemDto)
        {
            return new ItemEquipmentSet
            {
                Name = itemDto.SetName,
                ItemIds = ItemPathToModel(itemDto.SetItems)
            };
        }

        private List<ItemIdentifier> ItemPathToModel(IEnumerable<string> itemPathes)
        {
            var itemIdentifiers = new List<ItemIdentifier>();
            foreach (var itemPath in itemPathes)
                itemIdentifiers.Add(itemPath.ToItemIdentifier());
            return itemIdentifiers;
        }

        private List<ItemEquipmentSlot> SlotsToModel(ItemDto itemDto)
        {
            var slots = new List<ItemEquipmentSlot>();

            foreach (var slot in itemDto.Slots)
                switch (slot)
                {
                    case "neck":
                        slots.Add(ItemEquipmentSlot.Neck);
                        break;
                    case "right-hand":
                        if (!itemDto.Type.TwoHanded)
                            slots.Add(ItemEquipmentSlot.Offhand);
                        break;
                    case "left-hand":
                        slots.Add(ItemEquipmentSlot.Mainhand);
                        break;
                    case "waist":
                        slots.Add(ItemEquipmentSlot.Waist);
                        break;
                    case "feet":
                        slots.Add(ItemEquipmentSlot.Feet);
                        break;
                    case "bracers":
                        slots.Add(ItemEquipmentSlot.Wrists);
                        break;
                    case "torso":
                        slots.Add(ItemEquipmentSlot.Torso);
                        break;
                    case "hands":
                        slots.Add(ItemEquipmentSlot.Hands);
                        break;
                    case "head":
                        slots.Add(ItemEquipmentSlot.Head);
                        break;
                    case "legs":
                        slots.Add(ItemEquipmentSlot.Legs);
                        break;
                    case "left-finger":
                        slots.Add(ItemEquipmentSlot.LeftFinger);
                        break;
                    case "right-finger":
                        slots.Add(ItemEquipmentSlot.RightFinger);
                        break;
                    case "shoulders":
                        slots.Add(ItemEquipmentSlot.Shoulders);
                        break;
                    case "follower-left-finger":
                    case "follower-right-finger":
                    case "follower-right-hand":
                    case "follower-left-hand":
                    case "follower-neck":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return slots;
        }
    }
}