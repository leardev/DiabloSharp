using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class HeroMapper : Mapper<HeroDto, Hero>
    {
        private readonly HeroId _heroId;

        private readonly IEnumerable<DetailedItemDto> _items;

        private readonly IDictionary<FollowerId, IEnumerable<DetailedItemDto>> _itemsByFollower;

        public HeroMapper(HeroId heroId, DetailedHeroItemsDto items, DetailedFollowersDto followerItems)
        {
            _heroId = heroId;
            _items = ExtractItemsFromHero(items);
            _itemsByFollower = ExtractItemsFromFollowers(followerItems);
        }

        protected override void Map(HeroDto input, Hero output)
        {
            var gameMode = MapGameMode(input);
            var characterId = EnumConversionHelper.CharacterKindFromString(input.Class);
            var actives = MapActives(input.Class, input.Skills.Actives);
            var passives = MapPassives(input.Class, input.Skills.Passives);
            var items = MapEquipmentItems(_items);
            var followerItems = MapFollowerItems(_itemsByFollower);
            var cubeItems = MapCubeItems(input.LegendaryPowers);
            var stats = MapStats(input.Stats);

            output.Id = _heroId;
            output.Level = input.Level;
            output.Gender = (HeroGender)input.Gender;
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

        private GameModeId MapGameMode(HeroDto input)
        {
            if (input.Seasonal)
                return input.Hardcore ? GameModeId.SeasonHardcore : GameModeId.SeasonSoftcore;
            return input.Hardcore ? GameModeId.EraHardcore : GameModeId.EraSoftcore;
        }

        private IEnumerable<HeroSkillActive> MapActives(string characterId, IEnumerable<HeroActiveSkillDto> inputs)
        {
            var outputs = new List<HeroSkillActive>();
            foreach (var input in inputs)
            {
                var output = MapActive(characterId, input);
                outputs.Add(output);
            }

            return outputs;
        }

        private HeroSkillActive MapActive(string characterId, HeroActiveSkillDto input)
        {
            var runeId = default(CharacterSkillId);
            if (input.Rune != null)
                runeId = new CharacterSkillId(characterId, input.Rune.Slug);

            return new HeroSkillActive
            {
                Id = new CharacterSkillId(characterId, input.Skill.Slug),
                Rune = runeId
            };
        }

        private IEnumerable<HeroSkillPassive> MapPassives(string characterId, IEnumerable<HeroPassiveSkillDto> inputs)
        {
            var outputs = new List<HeroSkillPassive>();
            foreach (var input in inputs)
            {
                var output = MapPassive(characterId, input);
                outputs.Add(output);
            }

            return outputs;
        }

        private HeroSkillPassive MapPassive(string characterId, HeroPassiveSkillDto input)
        {
            return new HeroSkillPassive { Id = new CharacterSkillId(characterId, input.Skill.Slug) };
        }

        private IEnumerable<HeroItemEquipment> MapEquipmentItems(IEnumerable<DetailedItemDto> inputs)
        {
            var outputs = new List<HeroItemEquipment>();
            foreach (var input in inputs)
            {
                var output = MapEquipmentItem(input);
                outputs.Add(output);
            }

            return outputs;
        }

        private HeroItemEquipment MapEquipmentItem(DetailedItemDto input)
        {
            var slot = EnumConversionHelper.ItemEquipmentSlotFromString(input.Slots);

            var output = new HeroItemEquipment { Slot = slot };
            MapCustomizableItem(input, output);
            return output;
        }

        private IEnumerable<HeroItemFollower> MapFollowerItems(IDictionary<FollowerId, IEnumerable<DetailedItemDto>> inputs)
        {
            var outputs = new List<HeroItemFollower>();
            foreach (var pair in inputs)
            {
                foreach (var item in pair.Value)
                {
                    var output = MapFollowerItem(pair.Key, item);
                    outputs.Add(output);
                }
            }

            return outputs;
        }

        private HeroItemFollower MapFollowerItem(FollowerId followerId, DetailedItemDto input)
        {
            var slot = EnumConversionHelper.ItemFollowerSlotFromString(input.Slots);
            var output = new HeroItemFollower
            {
                Slot = slot,
                Follower = followerId
            };
            MapCustomizableItem(input, output);
            return output;
        }

        private void MapCustomizableItem(DetailedItemDto input, HeroItemCustomizable output)
        {
            var dyeId = ItemIdentifierHelper.FromItemDyeOptional(input.Dye);
            var transmogId = ItemIdentifierHelper.FromItemOptional(input.Transmog);
            var gems = MapGems(input.Gems);

            output.Id = ItemIdentifierHelper.FromItem(input);
            output.Dye = dyeId;
            output.Transmog = transmogId;
            output.Gems = gems;
        }

        private IEnumerable<HeroItemGem> MapGems(IEnumerable<DetailedItemGemDto> inputs)
        {
            if (inputs == null)
                return new List<HeroItemGem>();

            var outputs = new List<HeroItemGem>();
            foreach (var input in inputs)
            {
                var output = MapGem(input);
                outputs.Add(output);
            }

            return outputs;
        }

        private HeroItemGem MapGem(DetailedItemGemDto input)
        {
            return new HeroItemGem
            {
                Id = new ItemId(input.Item.Slug, input.Item.Id),
                IsLegendary = input.IsJewel,
                Rank = input.JewelRank.GetValueOrDefault(-1)
            };
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
            /* sometimes not all cube-items are avaible therefore the user has to resolve the ItemId to determine the cube-slot */
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

        private IEnumerable<DetailedItemDto> ExtractItemsFromHero(DetailedHeroItemsDto inputs)
        {
            var outputs = new[]
            {
                inputs.Head,
                inputs.Shoulders,
                inputs.Neck,
                inputs.Torso,
                inputs.Hands,
                inputs.Bracers,
                inputs.Waist,
                inputs.Legs,
                inputs.Feet,
                inputs.LeftFinger,
                inputs.RightFinger,
                inputs.MainHand,
                inputs.OffHand
            };

            return outputs.Where(dto => dto != null && !ItemIdentifierHelper.IsObsolete(dto));
        }

        private IDictionary<FollowerId, IEnumerable<DetailedItemDto>> ExtractItemsFromFollowers(DetailedFollowersDto inputs)
        {
            var templarItems = ExtractItemsFromFollower(inputs.Templar);
            var scoundrelItems = ExtractItemsFromFollower(inputs.Scoundrel);
            var enchantressItems = ExtractItemsFromFollower(inputs.Enchantress);

            var outputs = new Dictionary<FollowerId, IEnumerable<DetailedItemDto>>
            {
                { FollowerId.Templar, templarItems },
                { FollowerId.Scoundrel, scoundrelItems },
                { FollowerId.Enchantress, enchantressItems }
            };
            return outputs;
        }

        private IEnumerable<DetailedItemDto> ExtractItemsFromFollower(DetailedFollowerDto input)
        {
            var items = new List<DetailedItemDto>();
            if (input == null)
                return items;

            items.Add(input.Neck);
            items.Add(input.LeftFinger);
            items.Add(input.RightFinger);
            items.Add(input.MainHand);
            items.Add(input.OffHand);
            items.Add(input.Special);
            return items.Where(dto => dto != null && !ItemIdentifierHelper.IsObsolete(dto));
        }
    }
}