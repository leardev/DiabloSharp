using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemEquipmentConverter : ItemConverter<ItemEquipment>
    {
        private readonly Dictionary<string, ItemEquipmentKind> _itemEquipmentKindByTypeId;

        private readonly Dictionary<string, IEnumerable<CharacterClassIdentifier>> _classIdentifiersByTypeId;

        public ItemEquipmentConverter() : base(ItemCategory.Equipment)
        {
            #region kindByText

            _itemEquipmentKindByTypeId = new Dictionary<string, ItemEquipmentKind>
            {
                { "Amulet", ItemEquipmentKind.Amulet },
                { "Axe", ItemEquipmentKind.Axe },
                { "Axe2H", ItemEquipmentKind.Axe },
                { "Belt_Barbarian", ItemEquipmentKind.MightyBelt },
                { "Boots", ItemEquipmentKind.Boots },
                { "Boots_Barbarian", ItemEquipmentKind.Boots },
                { "Boots_Crusader", ItemEquipmentKind.Boots },
                { "Boots_DemonHunter", ItemEquipmentKind.Boots },
                { "Boots_Monk", ItemEquipmentKind.Boots },
                { "Boots_Necromancer", ItemEquipmentKind.Boots },
                { "Boots_WitchDoctor", ItemEquipmentKind.Boots },
                { "Boots_Wizard", ItemEquipmentKind.Boots },
                { "Bow", ItemEquipmentKind.Bow },
                { "Bracers", ItemEquipmentKind.Bracers },
                { "CeremonialDagger", ItemEquipmentKind.CeremonialKnife },
                { "ChestArmor", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_Barbarian", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_Crusader", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_DemonHunter", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_Monk", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_Necromancer", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_WitchDoctor", ItemEquipmentKind.ChestArmor },
                { "ChestArmor_Wizard", ItemEquipmentKind.ChestArmor },
                { "Cloak", ItemEquipmentKind.Cloak },
                { "CombatStaff", ItemEquipmentKind.Daibo },
                { "Crossbow", ItemEquipmentKind.Crossbow },
                { "CrusaderShield", ItemEquipmentKind.CrusaderShield },
                { "Dagger", ItemEquipmentKind.Dagger },
                { "FistWeapon", ItemEquipmentKind.FistWeapon },
                { "Flail1H", ItemEquipmentKind.Flail },
                { "Flail2H", ItemEquipmentKind.Flail },
                { "GenericBelt", ItemEquipmentKind.Belt },
                { "GenericChestArmor", ItemEquipmentKind.ChestArmor },
                { "GenericHelm", ItemEquipmentKind.Helm },
                { "Gloves", ItemEquipmentKind.Gloves },
                { "Gloves_Barbarian", ItemEquipmentKind.Gloves },
                { "Gloves_Crusader", ItemEquipmentKind.Gloves },
                { "Gloves_DemonHunter", ItemEquipmentKind.Gloves },
                { "Gloves_Monk", ItemEquipmentKind.Gloves },
                { "Gloves_Necromancer", ItemEquipmentKind.Gloves },
                { "Gloves_WitchDoctor", ItemEquipmentKind.Gloves },
                { "Gloves_Wizard", ItemEquipmentKind.Gloves },
                { "HandXbow", ItemEquipmentKind.HandCrossBow },
                { "Helm", ItemEquipmentKind.Helm },
                { "Helm_Barbarian", ItemEquipmentKind.Helm },
                { "Helm_Crusader", ItemEquipmentKind.Helm },
                { "Helm_DemonHunter", ItemEquipmentKind.Helm },
                { "Helm_Monk", ItemEquipmentKind.Helm },
                { "Helm_Necromancer", ItemEquipmentKind.Helm },
                { "Helm_WitchDoctor", ItemEquipmentKind.Helm },
                { "Helm_Wizard", ItemEquipmentKind.Helm },
                { "Legs", ItemEquipmentKind.Pants },
                { "Legs_Barbarian", ItemEquipmentKind.Pants },
                { "Legs_Crusader", ItemEquipmentKind.Pants },
                { "Legs_DemonHunter", ItemEquipmentKind.Pants },
                { "Legs_Monk", ItemEquipmentKind.Pants },
                { "Legs_Necromancer", ItemEquipmentKind.Pants },
                { "Legs_WitchDoctor", ItemEquipmentKind.Pants },
                { "Legs_Wizard", ItemEquipmentKind.Pants },
                { "Mace", ItemEquipmentKind.Mace },
                { "Mace2H", ItemEquipmentKind.Mace },
                { "MightyWeapon1H", ItemEquipmentKind.MightyWeapon },
                { "MightyWeapon2H", ItemEquipmentKind.MightyWeapon },
                { "Mojo", ItemEquipmentKind.Mojo },
                { "NecromancerOffhand", ItemEquipmentKind.Phylactery },
                { "Orb", ItemEquipmentKind.Source },
                { "Polearm", ItemEquipmentKind.Polearm },
                { "Quiver", ItemEquipmentKind.Quiver },
                { "Ring", ItemEquipmentKind.Ring },
                { "Scythe1H", ItemEquipmentKind.Scythe },
                { "Scythe2H", ItemEquipmentKind.Scythe },
                { "Shield", ItemEquipmentKind.Shield },
                { "Shoulders", ItemEquipmentKind.Shoulders },
                { "Shoulders_Barbarian", ItemEquipmentKind.Shoulders },
                { "Shoulders_Crusader", ItemEquipmentKind.Shoulders },
                { "Shoulders_DemonHunter", ItemEquipmentKind.Shoulders },
                { "Shoulders_Monk", ItemEquipmentKind.Shoulders },
                { "Shoulders_Necromancer", ItemEquipmentKind.Shoulders },
                { "Shoulders_WitchDoctor", ItemEquipmentKind.Shoulders },
                { "Shoulders_Wizard", ItemEquipmentKind.Shoulders },
                { "Spear", ItemEquipmentKind.Spear },
                { "SpiritStone_Monk", ItemEquipmentKind.SpiritStone },
                { "Staff", ItemEquipmentKind.Staff },
                { "Sword", ItemEquipmentKind.Sword },
                { "Sword2H", ItemEquipmentKind.Sword },
                { "VoodooMask", ItemEquipmentKind.VoodooMask },
                { "Wand", ItemEquipmentKind.Wand },
                { "WizardHat", ItemEquipmentKind.WizardHat }
            };

            #endregion

            #region classesByText

            var characterClasses = Enum.GetValues(typeof(CharacterClassIdentifier))
                .Cast<CharacterClassIdentifier>()
                .ToList();

            _classIdentifiersByTypeId = new Dictionary<string, IEnumerable<CharacterClassIdentifier>>
            {
                { "Amulet", characterClasses },
                { "Axe", characterClasses },
                { "Axe2H", new[] { CharacterClassIdentifier.Barbarian, CharacterClassIdentifier.Crusader, CharacterClassIdentifier.Monk, CharacterClassIdentifier.Necromancer, CharacterClassIdentifier.WitchDoctor, CharacterClassIdentifier.Wizard } },
                { "Belt_Barbarian", new[] { CharacterClassIdentifier.Barbarian} },
                { "Boots", characterClasses },
                { "Boots_Barbarian", new[] { CharacterClassIdentifier.Barbarian } },
                { "Boots_Crusader", new[] { CharacterClassIdentifier.Crusader } },
                { "Boots_DemonHunter", new[] { CharacterClassIdentifier.DemonHunter } },
                { "Boots_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "Boots_Necromancer", new[] { CharacterClassIdentifier.Necromancer } },
                { "Boots_WitchDoctor", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "Boots_Wizard", new[] { CharacterClassIdentifier.Wizard } },
                { "Bow", new[] { CharacterClassIdentifier.DemonHunter, CharacterClassIdentifier.WitchDoctor, CharacterClassIdentifier.Wizard } },
                { "Bracers", characterClasses },
                { "CeremonialDagger", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "ChestArmor", characterClasses },
                { "ChestArmor_Barbarian", new[] { CharacterClassIdentifier.Barbarian } },
                { "ChestArmor_Crusader", new[] { CharacterClassIdentifier.Crusader } },
                { "ChestArmor_DemonHunter", new[] { CharacterClassIdentifier.DemonHunter } },
                { "ChestArmor_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "ChestArmor_Necromancer", new[] { CharacterClassIdentifier.Necromancer } },
                { "ChestArmor_WitchDoctor", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "ChestArmor_Wizard", new[] { CharacterClassIdentifier.Wizard } },
                { "Cloak", new[] { CharacterClassIdentifier.DemonHunter } },
                { "CombatStaff", new[] { CharacterClassIdentifier.Monk } },
                { "Crossbow", new[] { CharacterClassIdentifier.DemonHunter, CharacterClassIdentifier.WitchDoctor, CharacterClassIdentifier.Wizard } },
                { "CrusaderShield", new[] { CharacterClassIdentifier.Crusader } },
                { "Dagger", characterClasses },
                { "FistWeapon", new[] { CharacterClassIdentifier.Monk } },
                { "Flail1H", new[] { CharacterClassIdentifier.Crusader } },
                { "Flail2H", new[] { CharacterClassIdentifier.Crusader } },
                { "GenericBelt", characterClasses },
                { "GenericChestArmor", characterClasses },
                { "GenericHelm", characterClasses },
                { "Gloves", characterClasses },
                { "Gloves_Barbarian", new[] { CharacterClassIdentifier.Barbarian } },
                { "Gloves_Crusader", new[] { CharacterClassIdentifier.Crusader } },
                { "Gloves_DemonHunter", new[] { CharacterClassIdentifier.DemonHunter } },
                { "Gloves_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "Gloves_Necromancer", new[] { CharacterClassIdentifier.Necromancer } },
                { "Gloves_WitchDoctor", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "Gloves_Wizard", new[] { CharacterClassIdentifier.Wizard } },
                { "HandXbow", new []{ CharacterClassIdentifier.DemonHunter } },
                { "Helm", characterClasses },
                { "Helm_Barbarian", new[] { CharacterClassIdentifier.Barbarian } },
                { "Helm_Crusader", new[] { CharacterClassIdentifier.Crusader } },
                { "Helm_DemonHunter", new[] { CharacterClassIdentifier.DemonHunter } },
                { "Helm_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "Helm_Necromancer", new[] { CharacterClassIdentifier.Necromancer } },
                { "Helm_WitchDoctor", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "Helm_Wizard", new[] { CharacterClassIdentifier.Wizard } },
                { "Legs", characterClasses },
                { "Legs_Barbarian", new[] { CharacterClassIdentifier.Barbarian } },
                { "Legs_Crusader", new[] { CharacterClassIdentifier.Crusader } },
                { "Legs_DemonHunter", new[] { CharacterClassIdentifier.DemonHunter } },
                { "Legs_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "Legs_Necromancer", new[] { CharacterClassIdentifier.Necromancer } },
                { "Legs_WitchDoctor", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "Legs_Wizard", new[] { CharacterClassIdentifier.Wizard } },
                { "Mace", characterClasses },
                { "Mace2H", new[] { CharacterClassIdentifier.Barbarian, CharacterClassIdentifier.Crusader, CharacterClassIdentifier.Monk, CharacterClassIdentifier.Necromancer, CharacterClassIdentifier.WitchDoctor, CharacterClassIdentifier.Wizard } },
                { "MightyWeapon1H", new[] { CharacterClassIdentifier.Barbarian } },
                { "MightyWeapon2H", new[] { CharacterClassIdentifier.Barbarian } },
                { "Mojo", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "NecromancerOffhand", new[] { CharacterClassIdentifier.Necromancer } },
                { "Orb", new[] { CharacterClassIdentifier.Wizard } },
                { "Polearm", new[] { CharacterClassIdentifier.Barbarian, CharacterClassIdentifier.Crusader, CharacterClassIdentifier.DemonHunter, CharacterClassIdentifier.Monk, CharacterClassIdentifier.WitchDoctor } },
                { "Quiver", new[] { CharacterClassIdentifier.DemonHunter } },
                { "Ring", characterClasses },
                { "Scythe1H", new[] { CharacterClassIdentifier.Necromancer } },
                { "Scythe2H", new[] { CharacterClassIdentifier.Necromancer } },
                { "Shield", characterClasses },
                { "Shoulders", characterClasses },
                { "Shoulders_Barbarian", new[] { CharacterClassIdentifier.Barbarian } },
                { "Shoulders_Crusader", new[] { CharacterClassIdentifier.Crusader } },
                { "Shoulders_DemonHunter", new[] { CharacterClassIdentifier.DemonHunter } },
                { "Shoulders_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "Shoulders_Necromancer", new[] { CharacterClassIdentifier.Necromancer } },
                { "Shoulders_WitchDoctor", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "Shoulders_Wizard", new[] { CharacterClassIdentifier.Wizard } },
                { "Spear", characterClasses },
                { "SpiritStone_Monk", new[] { CharacterClassIdentifier.Monk } },
                { "Staff", new[] { CharacterClassIdentifier.Monk, CharacterClassIdentifier.Necromancer, CharacterClassIdentifier.WitchDoctor, CharacterClassIdentifier.Wizard } },
                { "Sword", characterClasses },
                { "Sword2H", new[] { CharacterClassIdentifier.Barbarian, CharacterClassIdentifier.Crusader, CharacterClassIdentifier.Monk, CharacterClassIdentifier.Necromancer, CharacterClassIdentifier.WitchDoctor, CharacterClassIdentifier.Wizard } },
                { "VoodooMask", new[] { CharacterClassIdentifier.WitchDoctor } },
                { "Wand", new[] { CharacterClassIdentifier.Wizard } },
                { "WizardHat", new[] { CharacterClassIdentifier.Wizard } }
            };

            #endregion
        }

        public override ItemEquipment ItemToModel(ItemDto itemDto)
        {
            var item = base.ItemToModel(itemDto);
            item.Kind = _itemEquipmentKindByTypeId[itemDto.Type.Id];
            item.Slots = SlotsToModel(itemDto);
            item.Classes = _classIdentifiersByTypeId[itemDto.Type.Id];
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