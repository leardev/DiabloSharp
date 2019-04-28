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
                new CharacterName { Id = Gender.Male, Name = input.MaleName },
                new CharacterName { Id = Gender.Female, Name = input.FemaleName }
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

        public IEnumerable<CharacterSkillActive> MapActiveSkills(CharacterIdentifier characterId, IEnumerable<CharacterApiSkillDto> inputs)
        {
            var outputs = new List<CharacterSkillActive>();
            foreach (var input in inputs)
            {
                var output = MapActiveSkill(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        public CharacterSkillActive MapActiveSkill(CharacterIdentifier characterId, CharacterApiSkillDto input)
        {
            var runes = MapRunes(characterId, input.Runes);
            return new CharacterSkillActive
            {
                Id = new CharacterSkillIdentifier(characterId, input.Skill.Slug),
                Name = input.Skill.Name,
                Level = input.Skill.Level,
                TooltipUrl = input.Skill.TooltipUrl,
                IconUrl = input.Skill.Icon,
                Type = CharacterSkillType.Active,
                Runes = runes
            };
        }

        private IEnumerable<CharacterSkillActiveRune> MapRunes(CharacterIdentifier characterId, IEnumerable<CharacterRuneDto> inputs)
        {
            var outputs = new List<CharacterSkillActiveRune>();
            foreach (var input in inputs)
            {
                var output = MapRune(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private CharacterSkillActiveRune MapRune(CharacterIdentifier characterId, CharacterRuneDto input)
        {
            return new CharacterSkillActiveRune
            {
                Id = new CharacterSkillIdentifier(characterId, input.Slug),
                Name = input.Name,
                Level = input.Level
            };
        }

        private IEnumerable<CharacterSkillPassive> MapPassiveSkills(CharacterIdentifier characterId, IEnumerable<CharacterSkillDto> inputs)
        {
            var outputs = new List<CharacterSkillPassive>();
            foreach (var input in inputs)
            {
                var output = MapPassiveSkill(characterId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private CharacterSkillPassive MapPassiveSkill(CharacterIdentifier characterId, CharacterSkillDto input)
        {
            return new CharacterSkillPassive
            {
                Id = new CharacterSkillIdentifier(characterId, input.Slug),
                Name = input.Name,
                Level = input.Level,
                TooltipUrl = input.TooltipUrl,
                IconUrl = input.Icon,
                Type = CharacterSkillType.Passive
            };
        }
    }
}