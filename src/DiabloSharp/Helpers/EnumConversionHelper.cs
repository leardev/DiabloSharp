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

        public static ArtisanId ArtisanIdentifierFromString(string value)
        {
            switch (value)
            {
                case "blacksmith":
                    return ArtisanId.Blacksmith;
                case "jeweler":
                    return ArtisanId.Jeweler;
                case "mystic":
                    return ArtisanId.Mystic;

                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static string ArtisanIdentifierToString(ArtisanId value)
        {
           switch (value)
           {
                case ArtisanId.Blacksmith:
                    return "blacksmith";
                case ArtisanId.Jeweler:
                    return "jeweler";
                case ArtisanId.Mystic:
                    return "mystic";
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static CharacterSkillCategory CharacterSkillCategoryFromString(string value)
        {
            switch (value)
            {
                case "primary":
                    return CharacterSkillCategory.Primary;
                case "secondary":
                    return CharacterSkillCategory.Secondary;
                case "defensive":
                    return CharacterSkillCategory.Defensive;
                case "might":
                    return CharacterSkillCategory.Might;
                case "tactics":
                    return CharacterSkillCategory.Tactics;
                case "rage":
                    return CharacterSkillCategory.Rage;
                case "utility":
                    return CharacterSkillCategory.Utility;
                case "laws":
                    return CharacterSkillCategory.Laws;
                case "conviction":
                    return CharacterSkillCategory.Conviction;
                case "hunting":
                    return CharacterSkillCategory.Hunting;
                case "devices":
                    return CharacterSkillCategory.Devices;
                case "archery":
                    return CharacterSkillCategory.Archery;
                case "techniques":
                    return CharacterSkillCategory.Techniques;
                case "focus":
                    return CharacterSkillCategory.Focus;
                case "mantras":
                    return CharacterSkillCategory.Mantras;
                case "corpses":
                    return CharacterSkillCategory.Corpses;
                case "reanimation":
                    return CharacterSkillCategory.Reanimation;
                case "curses":
                    return CharacterSkillCategory.Curses;
                case "blood-bone":
                    return CharacterSkillCategory.BloodAndBone;
                case "terror":
                    return CharacterSkillCategory.Terror;
                case "decay":
                    return CharacterSkillCategory.Decay;
                case "voodoo":
                    return CharacterSkillCategory.Voodoo;
                case "force":
                    return CharacterSkillCategory.Force;
                case "conjuration":
                    return CharacterSkillCategory.Conjuration;
                case "mastery":
                    return CharacterSkillCategory.Mastery;
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

        public static FollowerId FollowerIdentifierFromString(string value)
        {
            switch (value)
            {
                case "templar":
                    return FollowerId.Templar;
                case "scoundrel":
                    return FollowerId.Scoundrel;
                case "enchantress":
                    return FollowerId.Enchantress;
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

        public static CharacterKind CharacterKindFromString(string value)
        {
            switch (value)
            {
                case "barbarian":
                    return CharacterKind.Barbarian;
                case "crusader":
                    return CharacterKind.Crusader;
                case "demon-hunter":
                    return CharacterKind.DemonHunter;
                case "monk":
                    return CharacterKind.Monk;
                case "necromancer":
                    return CharacterKind.Necromancer;
                case "witch-doctor":
                    return CharacterKind.WitchDoctor;
                case "wizard":
                    return CharacterKind.Wizard;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static string CharacterIdentifierToString(CharacterKind value)
        {
            switch (value)
            {
                case CharacterKind.Barbarian:
                    return "barbarian";
                case CharacterKind.Crusader:
                    return "crusader";
                case CharacterKind.DemonHunter:
                    return "demon-hunter";
                case CharacterKind.Monk:
                    return "monk";
                case CharacterKind.Necromancer:
                    return "necromancer";
                case CharacterKind.WitchDoctor:
                    return "witch-doctor";
                case CharacterKind.Wizard:
                    return "wizard";
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static IEnumerable<CharacterKind> CharacterIdentifiersFromString(string value)
        {
            var identifiers = new List<CharacterKind>();
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
                    identifiers.Add(CharacterKind.Barbarian);
                    identifiers.Add(CharacterKind.Crusader);
                    identifiers.Add(CharacterKind.DemonHunter);
                    identifiers.Add(CharacterKind.Monk);
                    identifiers.Add(CharacterKind.Necromancer);
                    identifiers.Add(CharacterKind.WitchDoctor);
                    identifiers.Add(CharacterKind.Wizard);
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
                    identifiers.Add(CharacterKind.Barbarian);
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
                    identifiers.Add(CharacterKind.Crusader);
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
                    identifiers.Add(CharacterKind.DemonHunter);
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
                    identifiers.Add(CharacterKind.Monk);
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
                    identifiers.Add(CharacterKind.Necromancer);
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
                    identifiers.Add(CharacterKind.WitchDoctor);
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
                    identifiers.Add(CharacterKind.Wizard);
                    break;
                case "Axe2H":
                case "Mace2H":
                case "Sword2H":
                    identifiers.Add(CharacterKind.Barbarian);
                    identifiers.Add(CharacterKind.Crusader);
                    identifiers.Add(CharacterKind.Monk);
                    identifiers.Add(CharacterKind.Necromancer);
                    identifiers.Add(CharacterKind.WitchDoctor);
                    identifiers.Add(CharacterKind.Wizard);
                    break;
                case "Polearm":
                    identifiers.Add(CharacterKind.Barbarian);
                    identifiers.Add(CharacterKind.Crusader);
                    identifiers.Add(CharacterKind.DemonHunter);
                    identifiers.Add(CharacterKind.Monk);
                    identifiers.Add(CharacterKind.WitchDoctor);
                    break;
                case "Bow":
                case "Crossbow":
                    identifiers.Add(CharacterKind.DemonHunter);
                    identifiers.Add(CharacterKind.WitchDoctor);
                    identifiers.Add(CharacterKind.Wizard);
                    break;
                case "Staff":
                    identifiers.Add(CharacterKind.Monk);
                    identifiers.Add(CharacterKind.Necromancer);
                    identifiers.Add(CharacterKind.WitchDoctor);
                    identifiers.Add(CharacterKind.Wizard);
                    break;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }

            return identifiers;
        }

        public static HeroStatId HeroStatIdentifierFromString(string value)
        {
            switch (value)
            {
                case "life":
                    return HeroStatId.Life;
                case "damage":
                    return HeroStatId.Damage;
                case "toughness":
                    return HeroStatId.Toughness;
                case "healing":
                    return HeroStatId.Healing;
                case "attackSpeed":
                    return HeroStatId.AttackSpeed;
                case "armor":
                    return HeroStatId.Armor;
                case "strength":
                    return HeroStatId.Strength;
                case "dexterity":
                    return HeroStatId.Dexterity;
                case "vitality":
                    return HeroStatId.Vitality;
                case "intelligence":
                    return HeroStatId.Intelligence;
                case "physicalResist":
                    return HeroStatId.PhysicalResistance;
                case "fireResist":
                    return HeroStatId.FireResistance;
                case "coldResist":
                    return HeroStatId.ColdResistance;
                case "lightningResist":
                    return HeroStatId.LightningResistance;
                case "poisonResist":
                    return HeroStatId.PoisonResistance;
                case "arcaneResist":
                    return HeroStatId.ArcaneResistance;
                case "blockChance":
                    return HeroStatId.BlockChance;
                case "blockAmountMin":
                    return HeroStatId.BlockAmountMinimum;
                case "blockAmountMax":
                    return HeroStatId.BlockAmountMaximum;
                case "goldFind":
                    return HeroStatId.GoldFind;
                case "critChance":
                    return HeroStatId.CriticalHitChance;
                case "thorns":
                    return HeroStatId.Thorns;
                case "lifeSteal":
                    return HeroStatId.LifeSteal;
                case "lifePerKill":
                    return HeroStatId.LifePerKill;
                case "lifeOnHit":
                    return HeroStatId.LifePerHit;
                case "primaryResource":
                    return HeroStatId.PrimaryResource;
                case "secondaryResource":
                    return HeroStatId.SecondaryResource;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }

        public static bool TryItemEquipmentSlotFromString(string value, out ItemEquipmentSlot slot)
        {
            switch (value)
            {
                case "neck":
                    slot = ItemEquipmentSlot.Neck;
                    break;
                case "right-hand":
                case "offHand": // detailed-hero-items
                    slot = ItemEquipmentSlot.Offhand;
                    break;
                case "left-hand":
                case "mainHand": // detailed-hero-items
                    slot = ItemEquipmentSlot.Mainhand;
                    break;
                case "waist":
                    slot = ItemEquipmentSlot.Waist;
                    break;
                case "feet":
                    slot = ItemEquipmentSlot.Feet;
                    break;
                case "bracers":
                    slot = ItemEquipmentSlot.Wrists;
                    break;
                case "torso":
                    slot = ItemEquipmentSlot.Torso;
                    break;
                case "hands":
                    slot = ItemEquipmentSlot.Hands;
                    break;
                case "head":
                    slot = ItemEquipmentSlot.Head;
                    break;
                case "legs":
                    slot = ItemEquipmentSlot.Legs;
                    break;
                case "left-finger":
                case "leftFinger": // detailed-hero-items
                    slot = ItemEquipmentSlot.LeftFinger;
                    break;
                case "right-finger":
                case "rightFinger": // detailed-hero-items
                    slot = ItemEquipmentSlot.RightFinger;
                    break;
                case "shoulders":
                    slot = ItemEquipmentSlot.Shoulders;
                    break;
                case "follower-left-finger":
                case "follower-right-finger":
                case "follower-right-hand":
                case "follower-left-hand":
                case "follower-neck":
                    slot = default;
                    return false;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }

            return true;
        }

        public static ItemEquipmentSlot ItemEquipmentSlotFromString(string value)
        {
            if (!TryItemEquipmentSlotFromString(value, out var slot))
                throw new DiabloApiEnumConversionException(nameof(value), value);
            return slot;
        }

        public static ItemFollowerSlot ItemFollowerSlotFromString(string value)
        {
            switch (value)
            {
                case "neck":
                    return ItemFollowerSlot.Neck;
                case "leftFinger":
                    return ItemFollowerSlot.LeftFinger;
                case "rightFinger":
                    return ItemFollowerSlot.RightFinger;
                case "mainHand":
                    return ItemFollowerSlot.Mainhand;
                case "offHand":
                    return ItemFollowerSlot.Offhand;
                case "special":
                    return ItemFollowerSlot.Special;
                default:
                    throw new DiabloApiEnumConversionException(nameof(value), value);
            }
        }
    }
}