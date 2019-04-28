using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class CharacterMapper : Mapper<CharacterClassDto, Character>
    {
        public IEnumerable<CharacterApiSkillDto> Actives { get; set; }

        protected override void Map(CharacterClassDto input, Character output)
        {
            var characterId = EnumConversionHelper.CharacterIdentifierFromString(input.Slug);
            var names = MapNames(input);
            var categories = MapSkillCategories(input.SkillCategories);

            var actives = MapActiveSkills(characterId, Actives)
                .ToList();
            var passives = MapPassiveSkills(characterId, input.Skills.Passives)
                .ToList();
            var skills = actives.Cast<CharacterSkill>().Concat(passives);

            output.Id = characterId;
            output.Name = input.Name;
            output.IconUrl = input.Icon;
            output.ActiveSkills = actives;
            output.PassiveSkills = passives;
            output.Skills = skills;
            output.Names = names;
            output.Categories = categories;
        }

        private IEnumerable<CharacterName> MapNames(CharacterClassDto input)
        {
            return new[]
            {
                new CharacterName { Id = HeroGender.Male, Name = input.MaleName },
                new CharacterName { Id = HeroGender.Female, Name = input.FemaleName }
            };
        }

        private IEnumerable<CharacterSkillCategory> MapSkillCategories(IEnumerable<CharacterSkillCategoryDto> inputs)
        {
            var outputs = new List<CharacterSkillCategory>();
            foreach (var input in inputs)
            {
                var output = EnumConversionHelper.CharacterSkillCategoryFromString(input.Slug);
                outputs.Add(output);
            }
            return outputs;
        }

        private IEnumerable<CharacterSkillActive> MapActiveSkills(CharacterId characterId, IEnumerable<CharacterApiSkillDto> inputs)
        {
            var outputs = new List<CharacterSkillActive>();
            foreach (var input in inputs)
            {
                var output = MapActiveSkill(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private CharacterSkillActive MapActiveSkill(CharacterId characterId, CharacterApiSkillDto input)
        {
            var runes = MapRunes(characterId, input.Runes);
            return new CharacterSkillActive
            {
                Id = new CharacterSkillId(characterId, input.Skill.Slug),
                Name = input.Skill.Name,
                Level = input.Skill.Level,
                TooltipUrl = input.Skill.TooltipUrl,
                IconUrl = input.Skill.Icon,
                Kind = CharacterSkillKind.Active,
                Runes = runes
            };
        }

        private IEnumerable<CharacterSkillActiveRune> MapRunes(CharacterId characterId, IEnumerable<CharacterRuneDto> inputs)
        {
            var outputs = new List<CharacterSkillActiveRune>();
            foreach (var input in inputs)
            {
                var output = MapRune(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private CharacterSkillActiveRune MapRune(CharacterId characterId, CharacterRuneDto input)
        {
            return new CharacterSkillActiveRune
            {
                Id = new CharacterSkillId(characterId, input.Slug),
                Name = input.Name,
                Level = input.Level
            };
        }

        private IEnumerable<CharacterSkillPassive> MapPassiveSkills(CharacterId characterId, IEnumerable<CharacterSkillDto> inputs)
        {
            var outputs = new List<CharacterSkillPassive>();
            foreach (var input in inputs)
            {
                var output = MapPassiveSkill(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private CharacterSkillPassive MapPassiveSkill(CharacterId characterId, CharacterSkillDto input)
        {
            return new CharacterSkillPassive
            {
                Id = new CharacterSkillId(characterId, input.Slug),
                Name = input.Name,
                Level = input.Level,
                TooltipUrl = input.TooltipUrl,
                IconUrl = input.Icon,
                Kind = CharacterSkillKind.Passive
            };
        }
    }
}