using System;
using System.Collections.Generic;
using DiabloSharp.Exceptions;
using DiabloSharp.Models;

namespace DiabloSharp.Helpers
{
    internal static class EnumConversionHelper
    {
        public static bool TryRegionFromString(string value, out Region region)
        {
            if (Enum.TryParse(value, out region))
                return true;

            region = default;
            switch (value)
            {
                case "eu":
                    region = Region.Europe;
                    break;
                case "kr":
                    region = Region.Korea;
                    break;
                case "tw":
                    region = Region.Taiwan;
                    break;
                case "us":
                    region = Region.UnitedStates;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public static string RegionToString(Region value)
        {
            switch (value)
            {
                case Region.Europe:
                    return "eu";
                case Region.Korea:
                    return "kr";
                case Region.Taiwan:
                    return "tw";
                case Region.UnitedStates:
                    return "us";
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static bool TryLocalizationFromString(string value, out Localization localization)
        {
            if (Enum.TryParse(value, out localization))
                return true;

            localization = default;
            switch (value)
            {
                case "en_US":
                    localization = Localization.EnglishUs;
                    break;
                case "en_GB":
                    localization = Localization.EnglishGb;
                    break;
                case "de_DE":
                    localization = Localization.German;
                    break;
                case "es_ES":
                    localization = Localization.Spanish;
                    break;
                case "fr_FR":
                    localization = Localization.French;
                    break;
                case "it_IT":
                    localization = Localization.Italian;
                    break;
                case "pl_PL":
                    localization = Localization.Polish;
                    break;
                case "pt_PT":
                    localization = Localization.Portuguese;
                    break;
                case "ru_RU":
                    localization = Localization.Russian;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public static string LocalizationToString(Localization value)
        {
            switch (value)
            {
                case Localization.EnglishUs:
                    return "en_US";
                case Localization.EnglishGb:
                    return "en_GB";
                case Localization.German:
                    return "de_DE";
                case Localization.Spanish:
                    return "es_ES";
                case Localization.French:
                    return "fr_FR";
                case Localization.Italian:
                    return "it_IT";
                case Localization.Polish:
                    return "pl_PL";
                case Localization.Portuguese:
                    return "pt_PT";
                case Localization.Russian:
                    return "ru_RU";
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static ItemQuality ItemQualityFromString(string value)
        {
            switch (value)
            {
                case "white":
                    return ItemQuality.Normal;
                case "blue":
                    return ItemQuality.Magic;
                case "yellow":
                    return ItemQuality.Rare;
                case "orange":
                    return ItemQuality.Legendary;
                case "green":
                    return ItemQuality.Set;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static ItemFollowerTokenKind ItemFollowerTokenKindFromString(string value)
        {
            switch (value)
            {
                case "EnchantressSpecial":
                    return ItemFollowerTokenKind.EnchantressFocus;
                case "ScoundrelSpecial":
                    return ItemFollowerTokenKind.ScoundrelToken;
                case "TemplarSpecial":
                    return ItemFollowerTokenKind.TemplarRelic;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static ItemEquipmentKind ItemEquipmentKindFromString(string value)
        {
            switch (value)
            {
                case "Amulet":
                    return ItemEquipmentKind.Amulet;
                case "Axe":
                    return ItemEquipmentKind.Axe;
                case "Axe2H":
                    return ItemEquipmentKind.Axe;
                case "Belt_Barbarian":
                    return ItemEquipmentKind.MightyBelt;
                case "Boots":
                    return ItemEquipmentKind.Boots;
                case "Boots_Barbarian":
                    return ItemEquipmentKind.Boots;
                case "Boots_Crusader":
                    return ItemEquipmentKind.Boots;
                case "Boots_DemonHunter":
                    return ItemEquipmentKind.Boots;
                case "Boots_Monk":
                    return ItemEquipmentKind.Boots;
                case "Boots_Necromancer":
                    return ItemEquipmentKind.Boots;
                case "Boots_WitchDoctor":
                    return ItemEquipmentKind.Boots;
                case "Boots_Wizard":
                    return ItemEquipmentKind.Boots;
                case "Bow":
                    return ItemEquipmentKind.Bow;
                case "Bracers":
                    return ItemEquipmentKind.Bracers;
                case "CeremonialDagger":
                    return ItemEquipmentKind.CeremonialKnife;
                case "ChestArmor":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_Barbarian":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_Crusader":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_DemonHunter":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_Monk":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_Necromancer":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_WitchDoctor":
                    return ItemEquipmentKind.ChestArmor;
                case "ChestArmor_Wizard":
                    return ItemEquipmentKind.ChestArmor;
                case "Cloak":
                    return ItemEquipmentKind.Cloak;
                case "CombatStaff":
                    return ItemEquipmentKind.Daibo;
                case "Crossbow":
                    return ItemEquipmentKind.Crossbow;
                case "CrusaderShield":
                    return ItemEquipmentKind.CrusaderShield;
                case "Dagger":
                    return ItemEquipmentKind.Dagger;
                case "FistWeapon":
                    return ItemEquipmentKind.FistWeapon;
                case "Flail1H":
                    return ItemEquipmentKind.Flail;
                case "Flail2H":
                    return ItemEquipmentKind.Flail;
                case "GenericBelt":
                    return ItemEquipmentKind.Belt;
                case "GenericChestArmor":
                    return ItemEquipmentKind.ChestArmor;
                case "GenericHelm":
                    return ItemEquipmentKind.Helm;
                case "Gloves":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_Barbarian":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_Crusader":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_DemonHunter":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_Monk":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_Necromancer":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_WitchDoctor":
                    return ItemEquipmentKind.Gloves;
                case "Gloves_Wizard":
                    return ItemEquipmentKind.Gloves;
                case "HandXbow":
                    return ItemEquipmentKind.HandCrossBow;
                case "Helm":
                    return ItemEquipmentKind.Helm;
                case "Helm_Barbarian":
                    return ItemEquipmentKind.Helm;
                case "Helm_Crusader":
                    return ItemEquipmentKind.Helm;
                case "Helm_DemonHunter":
                    return ItemEquipmentKind.Helm;
                case "Helm_Monk":
                    return ItemEquipmentKind.Helm;
                case "Helm_Necromancer":
                    return ItemEquipmentKind.Helm;
                case "Helm_WitchDoctor":
                    return ItemEquipmentKind.Helm;
                case "Helm_Wizard":
                    return ItemEquipmentKind.Helm;
                case "Legs":
                    return ItemEquipmentKind.Pants;
                case "Legs_Barbarian":
                    return ItemEquipmentKind.Pants;
                case "Legs_Crusader":
                    return ItemEquipmentKind.Pants;
                case "Legs_DemonHunter":
                    return ItemEquipmentKind.Pants;
                case "Legs_Monk":
                    return ItemEquipmentKind.Pants;
                case "Legs_Necromancer":
                    return ItemEquipmentKind.Pants;
                case "Legs_WitchDoctor":
                    return ItemEquipmentKind.Pants;
                case "Legs_Wizard":
                    return ItemEquipmentKind.Pants;
                case "Mace":
                    return ItemEquipmentKind.Mace;
                case "Mace2H":
                    return ItemEquipmentKind.Mace;
                case "MightyWeapon1H":
                    return ItemEquipmentKind.MightyWeapon;
                case "MightyWeapon2H":
                    return ItemEquipmentKind.MightyWeapon;
                case "Mojo":
                    return ItemEquipmentKind.Mojo;
                case "NecromancerOffhand":
                    return ItemEquipmentKind.Phylactery;
                case "Orb":
                    return ItemEquipmentKind.Source;
                case "Polearm":
                    return ItemEquipmentKind.Polearm;
                case "Quiver":
                    return ItemEquipmentKind.Quiver;
                case "Ring":
                    return ItemEquipmentKind.Ring;
                case "Scythe1H":
                    return ItemEquipmentKind.Scythe;
                case "Scythe2H":
                    return ItemEquipmentKind.Scythe;
                case "Shield":
                    return ItemEquipmentKind.Shield;
                case "Shoulders":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_Barbarian":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_Crusader":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_DemonHunter":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_Monk":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_Necromancer":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_WitchDoctor":
                    return ItemEquipmentKind.Shoulders;
                case "Shoulders_Wizard":
                    return ItemEquipmentKind.Shoulders;
                case "Spear":
                    return ItemEquipmentKind.Spear;
                case "SpiritStone_Monk":
                    return ItemEquipmentKind.SpiritStone;
                case "Staff":
                    return ItemEquipmentKind.Staff;
                case "Sword":
                    return ItemEquipmentKind.Sword;
                case "Sword2H":
                    return ItemEquipmentKind.Sword;
                case "VoodooMask":
                    return ItemEquipmentKind.VoodooMask;
                case "Wand":
                    return ItemEquipmentKind.Wand;
                case "WizardHat":
                    return ItemEquipmentKind.WizardHat;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static CharacterClassIdentifier CharacterClassIdentifierFromSlug(string value)
        {
            switch (value)
            {
                case "barbarian":
                    return CharacterClassIdentifier.Barbarian;
                case "crusader":
                    return CharacterClassIdentifier.Crusader;
                case "demon-hunter":
                    return CharacterClassIdentifier.DemonHunter;
                case "monk":
                    return CharacterClassIdentifier.Monk;
                case "necromancer":
                    return CharacterClassIdentifier.Necromancer;
                case "witch-doctor":
                    return CharacterClassIdentifier.WitchDoctor;
                case "wizard":
                    return CharacterClassIdentifier.Wizard;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static string CharacterClassIdentifierToSlug(CharacterClassIdentifier value)
        {
            switch (value)
            {
                case CharacterClassIdentifier.Barbarian:
                    return "barbarian";
                case CharacterClassIdentifier.Crusader:
                    return "crusader";
                case CharacterClassIdentifier.DemonHunter:
                    return "demon-hunter";
                case CharacterClassIdentifier.Monk:
                    return "monk";
                case CharacterClassIdentifier.Necromancer:
                    return "necromancer";
                case CharacterClassIdentifier.WitchDoctor:
                    return "witch-doctor";
                case CharacterClassIdentifier.Wizard:
                    return "wizard";
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static IEnumerable<CharacterClassIdentifier> CharacterClassIdentifiersFromItemTypeId(string value)
        {
            var identifiers = new List<CharacterClassIdentifier>();
            switch (value)
            {
                case "Amulet":
                case "Axe":
                case "Boots":
                case "Bracers":
                case "ChestArmor":
                case "Dagger":
                case "GenericBelt":
                case "GenericChestArmor":
                case "GenericHelm":
                case "Gloves":
                case "Helm":
                case "Legs":
                case "Mace":
                case "Ring":
                case "Shield":
                case "Shoulders":
                case "Spear":
                case "Sword":
                    identifiers.Add(CharacterClassIdentifier.Barbarian);
                    identifiers.Add(CharacterClassIdentifier.Crusader);
                    identifiers.Add(CharacterClassIdentifier.DemonHunter);
                    identifiers.Add(CharacterClassIdentifier.Monk);
                    identifiers.Add(CharacterClassIdentifier.Necromancer);
                    identifiers.Add(CharacterClassIdentifier.WitchDoctor);
                    identifiers.Add(CharacterClassIdentifier.Wizard);
                    break;
                case "Belt_Barbarian":
                case "Boots_Barbarian":
                case "ChestArmor_Barbarian":
                case "Gloves_Barbarian":
                case "Helm_Barbarian":
                case "Legs_Barbarian":
                case "MightyWeapon1H":
                case "MightyWeapon2H":
                case "Shoulders_Barbarian":
                    identifiers.Add(CharacterClassIdentifier.Barbarian);
                    break;
                case "ChestArmor_Crusader":
                case "Boots_Crusader":
                case "CrusaderShield":
                case "Flail1H":
                case "Flail2H":
                case "Gloves_Crusader":
                case "Helm_Crusader":
                case "Legs_Crusader":
                case "Shoulders_Crusader":
                    identifiers.Add(CharacterClassIdentifier.Crusader);
                    break;
                case "Boots_DemonHunter":
                case "ChestArmor_DemonHunter":
                case "Cloak":
                case "Gloves_DemonHunter":
                case "HandXbow":
                case "Helm_DemonHunter":
                case "Legs_DemonHunter":
                case "Quiver":
                case "Shoulders_DemonHunter":
                    identifiers.Add(CharacterClassIdentifier.DemonHunter);
                    break;
                case "Boots_Monk":
                case "ChestArmor_Monk":
                case "CombatStaff":
                case "FistWeapon":
                case "Gloves_Monk":
                case "Helm_Monk":
                case "Legs_Monk":
                case "Shoulders_Monk":
                case "SpiritStone_Monk":
                    identifiers.Add(CharacterClassIdentifier.Monk);
                    break;
                case "Boots_Necromancer":
                case "ChestArmor_Necromancer":
                case "Gloves_Necromancer":
                case "Helm_Necromancer":
                case "Legs_Necromancer":
                case "NecromancerOffhand":
                case "Scythe1H":
                case "Scythe2H":
                case "Shoulders_Necromancer":
                    identifiers.Add(CharacterClassIdentifier.Necromancer);
                    break;
                case "Boots_WitchDoctor":
                case "CeremonialDagger":
                case "ChestArmor_WitchDoctor":
                case "Gloves_WitchDoctor":
                case "Helm_WitchDoctor":
                case "Legs_WitchDoctor":
                case "Mojo":
                case "Shoulders_WitchDoctor":
                case "VoodooMask":
                    identifiers.Add(CharacterClassIdentifier.WitchDoctor);
                    break;

                case "Boots_Wizard":
                case "ChestArmor_Wizard":
                case "Gloves_Wizard":
                case "Helm_Wizard":
                case "Legs_Wizard":
                case "Orb":
                case "Shoulders_Wizard":
                case "Wand":
                case "WizardHat":
                    identifiers.Add(CharacterClassIdentifier.Wizard);
                    break;
                case "Axe2H":
                case "Mace2H":
                case "Sword2H":
                    identifiers.Add(CharacterClassIdentifier.Barbarian);
                    identifiers.Add(CharacterClassIdentifier.Crusader);
                    identifiers.Add(CharacterClassIdentifier.Monk);
                    identifiers.Add(CharacterClassIdentifier.Necromancer);
                    identifiers.Add(CharacterClassIdentifier.WitchDoctor);
                    identifiers.Add(CharacterClassIdentifier.Wizard);
                    break;
                case "Polearm":
                    identifiers.Add(CharacterClassIdentifier.Barbarian);
                    identifiers.Add(CharacterClassIdentifier.Crusader);
                    identifiers.Add(CharacterClassIdentifier.DemonHunter);
                    identifiers.Add(CharacterClassIdentifier.Monk);
                    identifiers.Add(CharacterClassIdentifier.WitchDoctor);
                    break;
                case "Bow":
                case "Crossbow":
                    identifiers.Add(CharacterClassIdentifier.DemonHunter);
                    identifiers.Add(CharacterClassIdentifier.WitchDoctor);
                    identifiers.Add(CharacterClassIdentifier.Wizard);
                    break;
                case "Staff":
                    identifiers.Add(CharacterClassIdentifier.Monk);
                    identifiers.Add(CharacterClassIdentifier.Necromancer);
                    identifiers.Add(CharacterClassIdentifier.WitchDoctor);
                    identifiers.Add(CharacterClassIdentifier.Wizard);
                    break;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }

            return identifiers;
        }

        public static HeroStatIdentifier HeroStatIdentifierFromString(string value)
        {
            switch (value)
            {
                case "life":
                    return HeroStatIdentifier.Life;
                case "damage":
                    return HeroStatIdentifier.Damage;
                case "toughness":
                    return HeroStatIdentifier.Toughness;
                case "healing":
                    return HeroStatIdentifier.Healing;
                case "attackSpeed":
                    return HeroStatIdentifier.AttackSpeed;
                case "armor":
                    return HeroStatIdentifier.Armor;
                case "strength":
                    return HeroStatIdentifier.Strength;
                case "dexterity":
                    return HeroStatIdentifier.Dexterity;
                case "vitality":
                    return HeroStatIdentifier.Vitality;
                case "intelligence":
                    return HeroStatIdentifier.Intelligence;
                case "physicalResist":
                    return HeroStatIdentifier.PhysicalResistance;
                case "fireResist":
                    return HeroStatIdentifier.FireResistance;
                case "coldResist":
                    return HeroStatIdentifier.ColdResistance;
                case "lightningResist":
                    return HeroStatIdentifier.LightningResistance;
                case "poisonResist":
                    return HeroStatIdentifier.PoisonResistance;
                case "arcaneResist":
                    return HeroStatIdentifier.ArcaneResistance;
                case "blockChance":
                    return HeroStatIdentifier.BlockChance;
                case "blockAmountMin":
                    return HeroStatIdentifier.BlockAmountMinimum;
                case "blockAmountMax":
                    return HeroStatIdentifier.BlockAmountMaximum;
                case "goldFind":
                    return HeroStatIdentifier.GoldFind;
                case "critChance":
                    return HeroStatIdentifier.CriticalHitChance;
                case "thorns":
                    return HeroStatIdentifier.Thorns;
                case "lifeSteal":
                    return HeroStatIdentifier.LifeSteal;
                case "lifePerKill":
                    return HeroStatIdentifier.LifePerKill;
                case "lifeOnHit":
                    return HeroStatIdentifier.LifePerHit;
                case "primaryResource":
                    return HeroStatIdentifier.PrimaryResource;
                case "secondaryResource":
                    return HeroStatIdentifier.SecondaryResource;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }
    }
}