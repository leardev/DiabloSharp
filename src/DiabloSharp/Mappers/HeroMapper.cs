using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class HeroMapper : Mapper<HeroDto, Hero>
    {
        public HeroIdentifier HeroId { get; set; }

        protected override void Map(HeroDto input, Hero output)
        {
            var gameMode = MapGameMode(input);
            var characterId = EnumConversionHelper.CharacterIdentifierFromString(input.Class);
            var actives = MapActives(characterId, input.Skills.Actives);
            var passives = MapPassives(characterId, input.Skills.Passives);
            var items = MapItems(input.Items);
            var followerItems = MapFollowerItems(input.Followers);
            var cubeItems = MapCubeItems(input.LegendaryPowers);
            var stats = MapStats(input.Stats);

            output.Id = HeroId;
            output.Level = input.Level;
            output.Gender = (Gender)input.Gender;
            output.Character = characterId;
            output.Name = input.Name;
            output.IsDead = false;
            output.GameMode = gameMode;
            output.HighestSoloRift = input.HighestSoloRiftCompleted;
            output.Actives = actives;
            output.Passives = passives;
            output.Items = items;
            output.FollowerItems = followerItems;
            output.CubeItems = cubeItems;
            output.Stats = stats;

        }

        private GameModeIdentifier MapGameMode(HeroDto input)
        {
            if (input.Seasonal)
                return input.Hardcore ? GameModeIdentifier.SeasonHardcore : GameModeIdentifier.SeasonSoftcore;
            return input.Hardcore ? GameModeIdentifier.EraHardcore : GameModeIdentifier.EraSoftcore;
        }

        private IEnumerable<HeroSkillActive> MapActives(CharacterIdentifier characterId, IEnumerable<HeroActiveSkillDto> inputs)
        {
            var outputs = new List<HeroSkillActive>();
            foreach (var input in inputs)
            {
                var output = MapActive(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private HeroSkillActive MapActive(CharacterIdentifier characterId, HeroActiveSkillDto input)
        {
            var runeId = default(SkillCharacterIdentifier);
            if (input.Rune != null)
                runeId = new SkillCharacterIdentifier(characterId, input.Rune.Slug);

            return new HeroSkillActive
            {
                Id = new SkillCharacterIdentifier(characterId, input.Skill.Slug),
                Rune = runeId
            };
        }

        private IEnumerable<HeroSkillPassive> MapPassives(CharacterIdentifier characterId, IEnumerable<HeroPassiveSkillDto> inputs)
        {
            var outputs = new List<HeroSkillPassive>();
            foreach (var input in inputs)
            {
                var output = MapPassive(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private HeroSkillPassive MapPassive(CharacterIdentifier characterId, HeroPassiveSkillDto input)
        {
            return new HeroSkillPassive { Id = new SkillCharacterIdentifier(characterId, input.Skill.Slug) };
        }

        private IEnumerable<HeroItemEquipment> MapItems(HeroItemsDto inputs)
        {
            var outputs = new List<HeroItemEquipment>();

            if (TryMapItem(ItemEquipmentSlot.Shoulders, inputs.Shoulders, out var output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Neck, inputs.Neck, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Torso, inputs.Torso, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Hands, inputs.Hands, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Wrists, inputs.Bracers, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Waist, inputs.Waist, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Legs, inputs.Legs, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Feet, inputs.Feet, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.LeftFinger, inputs.LeftFinger, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.RightFinger, inputs.RightFinger, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Mainhand, inputs.MainHand, out output))
                outputs.Add(output);
            if (TryMapItem(ItemEquipmentSlot.Offhand, inputs.OffHand, out output))
                outputs.Add(output);

            return outputs;
        }

        private bool TryMapItem(ItemEquipmentSlot slot, HeroItemDto input, out HeroItemEquipment output)
        {
            output = null;
            /* obsolete (e.g. items that are not updated after the patch that must be looted again) items have no TooltipParams */
            if (input == null || string.IsNullOrEmpty(input.TooltipParams))
                return false;

            var dyeId = ItemIdentifierHelper.FromItem(input.DyeColor);
            var transmogId = ItemIdentifierHelper.FromItem(input.TransmogItem);

            output = new HeroItemEquipment { Id = ItemIdentifierHelper.FromItem(input), Slot = slot, Dye = dyeId, Transmog = transmogId };
            return true;
        }

        private IEnumerable<HeroItemFollower> MapFollowerItems(HeroFollowersDto input)
        {
            var outputs = new List<HeroItemFollower>();

            if (TryMapFollowerItem(FollowerIdentifier.Templar, ItemEquipmentSlot.Neck, input.Templar.Items.Neck, out var output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Templar, ItemEquipmentSlot.LeftFinger, input.Templar.Items.LeftFinger, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Templar, ItemEquipmentSlot.RightFinger, input.Templar.Items.RightFinger, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Templar, ItemEquipmentSlot.Mainhand, input.Templar.Items.MainHand, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Templar, ItemEquipmentSlot.Offhand, input.Templar.Items.OffHand, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.Neck, input.Scoundrel.Items.Neck, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.LeftFinger, input.Scoundrel.Items.LeftFinger, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.RightFinger, input.Scoundrel.Items.RightFinger, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.Mainhand, input.Scoundrel.Items.MainHand, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Scoundrel, ItemEquipmentSlot.Offhand, input.Scoundrel.Items.OffHand, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Enchantress, ItemEquipmentSlot.Neck, input.Enchantress.Items.Neck, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Enchantress, ItemEquipmentSlot.LeftFinger, input.Enchantress.Items.LeftFinger, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Enchantress, ItemEquipmentSlot.RightFinger, input.Enchantress.Items.RightFinger, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Enchantress, ItemEquipmentSlot.Mainhand, input.Enchantress.Items.MainHand, out output))
                outputs.Add(output);
            if (TryMapFollowerItem(FollowerIdentifier.Enchantress, ItemEquipmentSlot.Offhand, input.Enchantress.Items.OffHand, out output))
                outputs.Add(output);

            return outputs;
        }

        private bool TryMapFollowerItem(FollowerIdentifier follower, ItemEquipmentSlot slot, HeroItemDto input, out HeroItemFollower output)
        {
            output = null;
            if (input == null)
                return false;

            var dyeId = ItemIdentifierHelper.FromItem(input.DyeColor);
            var transmogId = ItemIdentifierHelper.FromItem(input.TransmogItem);

            /* use ItemEquipmentSlot for follower items, because follower-tokens are not available */
            output = new HeroItemFollower { Follower = follower, Id = ItemIdentifierHelper.FromItem(input), Slot = slot, Dye = dyeId, Transmog = transmogId };
            return true;
        }

        private IEnumerable<HeroItemCube> MapCubeItems(IEnumerable<HeroItemDto> inputs)
        {
            var outputs = new List<HeroItemCube>();
            foreach (var input in inputs)
            {
                var output = MapCubeItem(input);
                outputs.Add(output);
            }
            return outputs;
        }

        private HeroItemCube MapCubeItem(HeroItemDto input)
        {
            /* sometimes not all cube-items are avaible therefore the user has to resolve the ItemIdentifier to determine the cube-slot */
            return new HeroItemCube { Id = ItemIdentifierHelper.FromItem(input) };
        }

        private IEnumerable<HeroStat> MapStats(Dictionary<string, double> inputs)
        {
            var outputs = new List<HeroStat>();
            foreach (var input in inputs)
            {
                var output = MapStat(input);
                outputs.Add(output);
            }
            return outputs;
        }

        private HeroStat MapStat(KeyValuePair<string, double> input)
        {
            return new HeroStat
            {
                Id = EnumConversionHelper.HeroStatIdentifierFromString(input.Key),
                Value = input.Value
            };
        }
    }
}