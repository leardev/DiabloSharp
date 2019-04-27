using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class HeroConverter
    {
        public Hero HeroToModel(HeroIdentifier heroIdentifier, HeroDto heroDto)
        {
            var gameMode = GameModeToModel(heroDto);
            var characterClass = EnumConversionHelper.CharacterClassIdentifierFromSlug(heroDto.Class);
            var passives = PassivesToModel(characterClass, heroDto);
            var actives = ActivesToModel(characterClass, heroDto);
            var items = ItemsToModel(heroDto);
            var followerItems = FollowerItemsToModel(heroDto);
            var cubeItems = CubeItemsToModel(heroDto);
            var stats = StatsToModel(heroDto);

            return new Hero
            {
                Id = heroIdentifier,
                Level = heroDto.Level,
                Gender = (Gender) heroDto.Gender,
                Class = characterClass,
                Name = heroDto.Name,
                IsDead = false,
                GameMode = gameMode,
                HighestSoloRift = heroDto.HighestSoloRiftCompleted,
                Actives = actives,
                Passives = passives,
                Items = items,
                FollowerItems = followerItems,
                CubeItems = cubeItems,
                Stats = stats
            };
        }

        private List<HeroStat> StatsToModel(HeroDto heroDto)
        {
            var stats = new List<HeroStat>();

            foreach (var heroStatDto in heroDto.Stats)
            {
                var stat = new HeroStat
                {
                    Id = EnumConversionHelper.HeroStatIdentifierFromString(heroStatDto.Key),
                    Value = heroStatDto.Value
                };
                stats.Add(stat);
            }

            return stats;
        }

        private GameModeIdentifier GameModeToModel(HeroDto heroDto)
        {
            if (heroDto.Seasonal)
                return heroDto.Hardcore ? GameModeIdentifier.SeasonHardcore : GameModeIdentifier.SeasonSoftcore;
            return heroDto.Hardcore ? GameModeIdentifier.EraHardcore : GameModeIdentifier.EraSoftcore;
        }

        private List<HeroSkillActive> ActivesToModel(CharacterClassIdentifier characterClass, HeroDto heroDto)
        {
            var actives = new List<HeroSkillActive>();
            foreach (var activeDto in heroDto.Skills.Actives)
            {
                var runeId = default(SkillIdentifier);
                if (activeDto.Rune != null)
                    runeId = new SkillIdentifier(characterClass, activeDto.Rune.Slug);

                var skill = new HeroSkillActive
                {
                    Id = new SkillIdentifier(characterClass, activeDto.Skill.Slug),
                    Rune = runeId
                };
                actives.Add(skill);
            }

            return actives;
        }

        private List<HeroSkillPassive> PassivesToModel(CharacterClassIdentifier characterClass, HeroDto heroDto)
        {
            var passivesDto = heroDto.Skills.Passives
                .Select(dto => dto.Skill);

            var passives = new List<HeroSkillPassive>();
            foreach (var passiveDto in passivesDto)
            {
                var passive = new HeroSkillPassive { Id = new SkillIdentifier(characterClass, passiveDto.Slug) };
                passives.Add(passive);
            }

            return passives;
        }

        private List<HeroItemEquipment> ItemsToModel(HeroDto heroDto)
        {
            var items = new List<HeroItemEquipment>();

            if (TryItemToModel(ItemEquipmentSlot.Shoulders, heroDto.Items.Shoulders, out var item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Neck, heroDto.Items.Neck, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Torso, heroDto.Items.Torso, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Hands, heroDto.Items.Hands, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Wrists, heroDto.Items.Bracers, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Waist, heroDto.Items.Waist, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Legs, heroDto.Items.Legs, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Feet, heroDto.Items.Feet, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.LeftFinger, heroDto.Items.LeftFinger, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.RightFinger, heroDto.Items.RightFinger, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Mainhand, heroDto.Items.MainHand, out item))
                items.Add(item);
            if (TryItemToModel(ItemEquipmentSlot.Offhand, heroDto.Items.OffHand, out item))
                items.Add(item);

            return items;
        }

        private bool TryItemToModel(ItemEquipmentSlot slot, HeroItemDto itemDto, out HeroItemEquipment item)
        {
            item = null;
            /* obsolete (e.g. items that are not updated after the patch that must be looted again) items have no TooltipParams */
            if (itemDto == null || string.IsNullOrEmpty(itemDto.TooltipParams))
                return false;

            var dyeId = itemDto.DyeColor?.TooltipParams.ToItemIdentifier();
            var transmogId = itemDto.TransmogItem?.TooltipParams.ToItemIdentifier();

            item = new HeroItemEquipment { Id = itemDto.TooltipParams.ToItemIdentifier(), Slot = slot, Dye = dyeId, Transmog = transmogId };
            return true;
        }

        private List<HeroItemFollower> FollowerItemsToModel(HeroDto heroDto)
        {
            var items = new List<HeroItemFollower>();

            if (TryFollowerItemsToModel(FollowerIdentifier.Templar, ItemEquipmentSlot.Neck, heroDto.Followers.Templar.Items.Neck, out var item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Templar, ItemEquipmentSlot.LeftFinger, heroDto.Followers.Templar.Items.LeftFinger, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Templar, ItemEquipmentSlot.RightFinger, heroDto.Followers.Templar.Items.RightFinger, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Templar, ItemEquipmentSlot.Mainhand, heroDto.Followers.Templar.Items.MainHand, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Templar, ItemEquipmentSlot.Offhand, heroDto.Followers.Templar.Items.OffHand, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.Neck, heroDto.Followers.Scoundrel.Items.Neck, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.LeftFinger, heroDto.Followers.Scoundrel.Items.LeftFinger, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.RightFinger, heroDto.Followers.Scoundrel.Items.RightFinger, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.Mainhand, heroDto.Followers.Scoundrel.Items.MainHand, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.Offhand, heroDto.Followers.Scoundrel.Items.OffHand, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Enchantress, ItemEquipmentSlot.Neck, heroDto.Followers.Enchantress.Items.Neck, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Enchantress, ItemEquipmentSlot.LeftFinger, heroDto.Followers.Enchantress.Items.LeftFinger, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Enchantress, ItemEquipmentSlot.RightFinger, heroDto.Followers.Enchantress.Items.RightFinger, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Enchantress, ItemEquipmentSlot.Mainhand, heroDto.Followers.Enchantress.Items.MainHand, out item))
                items.Add(item);
            if (TryFollowerItemsToModel(FollowerIdentifier.Enchantress, ItemEquipmentSlot.Offhand, heroDto.Followers.Enchantress.Items.OffHand, out item))
                items.Add(item);

            return items;
        }

        private bool TryFollowerItemsToModel(FollowerIdentifier follower, ItemEquipmentSlot slot, HeroItemDto itemDto, out HeroItemFollower item)
        {
            item = null;
            if (itemDto == null)
                return false;

            var dyeId = itemDto.DyeColor?.TooltipParams.ToItemIdentifier();
            var transmogId = itemDto.TransmogItem?.TooltipParams.ToItemIdentifier();

            item = new HeroItemFollower { Follower = follower, Id = itemDto.TooltipParams.ToItemIdentifier(), Slot = slot, Dye = dyeId, Transmog = transmogId };
            return true;
        }

        private List<HeroItemCube> CubeItemsToModel(HeroDto heroDto)
        {
            var cubeItems = new List<HeroItemCube>();
            foreach (var legendaryPowerDto in heroDto.LegendaryPowers)
            {
                var cubeItem = new HeroItemCube { Id = legendaryPowerDto.TooltipParams.ToItemIdentifier() };
                cubeItems.Add(cubeItem);
            }

            return cubeItems;
        }
    }
}