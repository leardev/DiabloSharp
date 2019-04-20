using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Features;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ItemConverter
    {
        private readonly Dictionary<string, ItemKind> _kindByText;

        private readonly Dictionary<string, IEnumerable<CharacterClassIdentifier>> _classesByText;

        private readonly Dictionary<string, ItemQuality> _qualityByText;

        public ItemConverter()
        {
            #region kindByText

            _kindByText = new Dictionary<string, ItemKind>
            {
                { "Amulet", ItemKind.Amulet },
                { "Axe", ItemKind.Axe },
                { "Axe2H", ItemKind.Axe },
                { "Belt_Barbarian", ItemKind.MightyBelt },
                { "Boots", ItemKind.Boots },
                { "Boots_Barbarian", ItemKind.Boots },
                { "Boots_Crusader", ItemKind.Boots },
                { "Boots_DemonHunter", ItemKind.Boots },
                { "Boots_Monk", ItemKind.Boots },
                { "Boots_Necromancer", ItemKind.Boots },
                { "Boots_WitchDoctor", ItemKind.Boots },
                { "Boots_Wizard", ItemKind.Boots },
                { "Bow", ItemKind.Bow },
                { "Bracers", ItemKind.Bracers },
                { "CeremonialDagger", ItemKind.CeremonialKnife },
                { "ChestArmor", ItemKind.ChestArmor },
                { "ChestArmor_Barbarian", ItemKind.ChestArmor },
                { "ChestArmor_Crusader", ItemKind.ChestArmor },
                { "ChestArmor_DemonHunter", ItemKind.ChestArmor },
                { "ChestArmor_Monk", ItemKind.ChestArmor },
                { "ChestArmor_Necromancer", ItemKind.ChestArmor },
                { "ChestArmor_WitchDoctor", ItemKind.ChestArmor },
                { "ChestArmor_Wizard", ItemKind.ChestArmor },
                { "Cloak", ItemKind.Cloak },
                { "CombatStaff", ItemKind.Daibo },
                { "Crossbow", ItemKind.Crossbow },
                { "CrusaderShield", ItemKind.CrusaderShield },
                { "Dagger", ItemKind.Dagger },
                { "FistWeapon", ItemKind.FistWeapon },
                { "Flail1H", ItemKind.Flail },
                { "Flail2H", ItemKind.Flail },
                { "GenericBelt", ItemKind.Belt },
                { "GenericChestArmor", ItemKind.ChestArmor },
                { "GenericHelm", ItemKind.Helm },
                { "Gloves", ItemKind.Gloves },
                { "Gloves_Barbarian", ItemKind.Gloves },
                { "Gloves_Crusader", ItemKind.Gloves },
                { "Gloves_DemonHunter", ItemKind.Gloves },
                { "Gloves_Monk", ItemKind.Gloves },
                { "Gloves_Necromancer", ItemKind.Gloves },
                { "Gloves_WitchDoctor", ItemKind.Gloves },
                { "Gloves_Wizard", ItemKind.Gloves },
                { "HandXbow", ItemKind.HandCrossBow },
                { "Helm", ItemKind.Helm },
                { "Helm_Barbarian", ItemKind.Helm },
                { "Helm_Crusader", ItemKind.Helm },
                { "Helm_DemonHunter", ItemKind.Helm },
                { "Helm_Monk", ItemKind.Helm },
                { "Helm_Necromancer", ItemKind.Helm },
                { "Helm_WitchDoctor", ItemKind.Helm },
                { "Helm_Wizard", ItemKind.Helm },
                { "Legs", ItemKind.Pants },
                { "Legs_Barbarian", ItemKind.Pants },
                { "Legs_Crusader", ItemKind.Pants },
                { "Legs_DemonHunter", ItemKind.Pants },
                { "Legs_Monk", ItemKind.Pants },
                { "Legs_Necromancer", ItemKind.Pants },
                { "Legs_WitchDoctor", ItemKind.Pants },
                { "Legs_Wizard", ItemKind.Pants },
                { "Mace", ItemKind.Mace },
                { "Mace2H", ItemKind.Mace },
                { "MightyWeapon1H", ItemKind.MightyWeapon },
                { "MightyWeapon2H", ItemKind.MightyWeapon },
                { "Mojo", ItemKind.Mojo },
                { "NecromancerOffhand", ItemKind.Phylactery },
                { "Orb", ItemKind.Source },
                { "Polearm", ItemKind.Polearm },
                { "Quiver", ItemKind.Quiver },
                { "Ring", ItemKind.Ring },
                { "Scythe1H", ItemKind.Scythe },
                { "Scythe2H", ItemKind.Scythe },
                { "Shield", ItemKind.Shield },
                { "Shoulders", ItemKind.Shoulders },
                { "Shoulders_Barbarian", ItemKind.Shoulders },
                { "Shoulders_Crusader", ItemKind.Shoulders },
                { "Shoulders_DemonHunter", ItemKind.Shoulders },
                { "Shoulders_Monk", ItemKind.Shoulders },
                { "Shoulders_Necromancer", ItemKind.Shoulders },
                { "Shoulders_WitchDoctor", ItemKind.Shoulders },
                { "Shoulders_Wizard", ItemKind.Shoulders },
                { "Spear", ItemKind.Spear },
                { "SpiritStone_Monk", ItemKind.SpiritStone },
                { "Staff", ItemKind.Staff },
                { "Sword", ItemKind.Sword },
                { "Sword2H", ItemKind.Sword },
                { "VoodooMask", ItemKind.VoodooMask },
                { "Wand", ItemKind.Wand },
                { "WizardHat", ItemKind.WizardHat }
            };

            #endregion

            #region classesByText

            var characterClasses = Enum.GetValues(typeof(CharacterClassIdentifier))
                .Cast<CharacterClassIdentifier>()
                .ToList();

            _classesByText = new Dictionary<string, IEnumerable<CharacterClassIdentifier>>
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

            #region qualityByText

            _qualityByText = new Dictionary<string, ItemQuality>
            {
                { "white", ItemQuality.Common },
                { "blue", ItemQuality.Magic },
                { "yellow", ItemQuality.Rare },
                { "orange", ItemQuality.Legendary },
                { "green", ItemQuality.Set }
            };

            #endregion
        }

        public Item ItemToModel(ItemDto itemDto)
        {
            var tooltip = new Tooltip
            {
                Description = itemDto.Description,
                DescriptionHtml = itemDto.DescriptionHtml,
                FlavorText = itemDto.FlavorText,
                FlavorTextHtml = itemDto.FlavorTextHtml,
                IconUrl = itemDto.Icon,
                Url = itemDto.TooltipParams
            };
            var slots = SlotsToModel(itemDto);

            var item = new Item
            {
                Id = new ItemIdentifier(itemDto.Id, itemDto.Slug),
                Name = itemDto.Name,
                Tooltip = tooltip,
                Slots = slots,
                RequiredLevel = itemDto.RequiredLevel,
                AccountBound = itemDto.AccountBound,
                IsSeasonRequiredToDrop = itemDto.IsSeasonRequiredToDrop,
                SeasonRequiredToDrop = itemDto.SeasonRequiredToDrop,
                Quality = _qualityByText[itemDto.Color],
                Classes = _classesByText[itemDto.Type.Id],
                Kind = _kindByText[itemDto.Type.Id]
            };

            if (item.Quality == ItemQuality.Set)
            {
                var itemSetFeature = SetToModel(itemDto);
                item.AddFeature(itemSetFeature);
            }

            if (!string.IsNullOrEmpty(itemDto.Dps))
            {
                var itemWeaponFeature = WeaponToModel(itemDto);
                item.AddFeature(itemWeaponFeature);
            }

            if (!string.IsNullOrEmpty(itemDto.Armor))
            {
                var itemArmorFeature = ArmorToModel(itemDto);
                item.AddFeature(itemArmorFeature);
            }

            return item;
        }

        private ItemArmorFeature ArmorToModel(ItemDto itemDto)
        {
            return new ItemArmorFeature
            {
                Armor = itemDto.Armor,
                ArmorHtml = itemDto.ArmorHtml,
                Block = itemDto.Block,
                BlockHtml = itemDto.BlockHtml
            };
        }

        private ItemWeaponFeature WeaponToModel(ItemDto itemDto)
        {
            return new ItemWeaponFeature
            {
                Damage = itemDto.Damage,
                DamageHtml = itemDto.DamageHtml,
                Dps = itemDto.Dps,
                TwoHanded = itemDto.Type.TwoHanded
            };
        }

        private ItemSetFeature SetToModel(ItemDto itemDto)
        {
            var tooltip = new Tooltip
            {
                Description = itemDto.SetDescription,
                DescriptionHtml = itemDto.SetDescriptionHtml
            };

            return new ItemSetFeature
            {
                Id = itemDto.SetName,
                NameHtml = itemDto.SetNameHtml,
                Tooltip = tooltip,
                ItemIds = ItemPathToModel(itemDto.SetItems)
            };
        }

        private IEnumerable<ItemIdentifier> ItemPathToModel(IEnumerable<string> itemPaths)
        {
            var setItemIds = new List<ItemIdentifier>();
            foreach (var itemPath in itemPaths)
            {
                var pathIndex = itemPath.IndexOf("/", StringComparison.Ordinal);
                var slugIndex = itemPath.LastIndexOf("-", StringComparison.Ordinal);
                var slug = itemPath.Substring(pathIndex + 1, slugIndex - pathIndex - 1);
                var id = itemPath.Substring(slugIndex + 1, itemPath.Length - slugIndex - 1);
                setItemIds.Add(new ItemIdentifier(id, slug));
            }

            return setItemIds;
        }

        private IEnumerable<ItemSlot> SlotsToModel(ItemDto itemDto)
        {
            var slots = new List<ItemSlot>();

            foreach (var slot in itemDto.Slots)
                switch (slot)
                {
                    case "neck":
                        slots.Add(ItemSlot.Neck);
                        break;
                    case "right-hand":
                        if (!itemDto.Type.TwoHanded)
                            slots.Add(ItemSlot.Offhand);
                        break;
                    case "left-hand":
                        slots.Add(ItemSlot.Mainhand);
                        break;
                    case "waist":
                        slots.Add(ItemSlot.Waist);
                        break;
                    case "feet":
                        slots.Add(ItemSlot.Feet);
                        break;
                    case "bracers":
                        slots.Add(ItemSlot.Wrists);
                        break;
                    case "torso":
                        slots.Add(ItemSlot.Torso);
                        break;
                    case "hands":
                        slots.Add(ItemSlot.Hands);
                        break;
                    case "head":
                        slots.Add(ItemSlot.Head);
                        break;
                    case "legs":
                        slots.Add(ItemSlot.Legs);
                        break;
                    case "left-finger":
                        slots.Add(ItemSlot.LeftFinger);
                        break;
                    case "right-finger":
                        slots.Add(ItemSlot.RightFinger);
                        break;
                    case "shoulders":
                        slots.Add(ItemSlot.Shoulders);
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

        public IEnumerable<Item> ItemsToModel(IEnumerable<ItemDto> itemDtos)
        {
            return itemDtos.Select(ItemToModel);
        }
    }
}