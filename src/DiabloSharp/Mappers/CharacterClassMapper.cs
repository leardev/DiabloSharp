using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class CharacterClassMapper : Mapper<CharacterClassDto, CharacterClass>
    {
        public IEnumerable<CharacterApiSkillDto> Actives { get; set; }

        protected override void Map(CharacterClassDto input, CharacterClass output)
        {
            var characterClass = EnumConversionHelper.CharacterClassIdentifierFromString(input.Slug);
            var names = MapNames(input);

            var actives = MapActiveSkills(characterClass, Actives)
                .ToList();
            var passives = MapPassiveSkills(characterClass, input.Skills.Passives)
                .ToList();
            var skills = actives.Cast<SkillCharacter>().Concat(passives);

            output.Id = characterClass;
            output.Name = input.Name;
            output.IconUrl = input.Icon;
            output.ActiveSkills = actives;
            output.PassiveSkills = passives;
            output.Skills = skills;
            output.Names = names;
        }

        private IEnumerable<CharacterName> MapNames(CharacterClassDto input)
        {
            return new[]
            {
                new CharacterName { Id = Gender.Male, Name = input.MaleName },
                new CharacterName { Id = Gender.Female, Name = input.FemaleName }
            };
        }

        public IEnumerable<SkillCharacterActive> MapActiveSkills(CharacterClassIdentifier characterClass, IEnumerable<CharacterApiSkillDto> inputs)
        {
            var outputs = new List<SkillCharacterActive>();
            foreach (var input in inputs)
            {
                var output = MapActiveSkill(characterClass, input);
                outputs.Add(output);
            }
            return outputs;
        }

        public SkillCharacterActive MapActiveSkill(CharacterClassIdentifier characterClass, CharacterApiSkillDto input)
        {
            var runes = MapRunes(characterClass, input.Runes);
            return new SkillCharacterActive
            {
                Id = new SkillIdentifier(characterClass, input.Skill.Slug),
                Name = input.Skill.Name,
                Level = input.Skill.Level,
                TooltipUrl = input.Skill.TooltipUrl,
                IconUrl = input.Skill.Icon,
                Category = SkillCategory.Active,
                Runes = runes
            };
        }

        private IEnumerable<SkillRune> MapRunes(CharacterClassIdentifier characterClass, IEnumerable<CharacterRuneDto> inputs)
        {
            var outputs = new List<SkillRune>();
            foreach (var input in inputs)
            {
                var output = MapRune(characterClass, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private SkillRune MapRune(CharacterClassIdentifier characterClass, CharacterRuneDto input)
        {
            return new SkillRune
            {
                Id = new SkillIdentifier(characterClass, input.Slug),
                Name = input.Name,
                Level = input.Level
            };
        }

        private IEnumerable<SkillCharacterPassive> MapPassiveSkills(CharacterClassIdentifier characterClass, IEnumerable<CharacterSkillDto> inputs)
        {
            var outputs = new List<SkillCharacterPassive>();
            foreach (var input in inputs)
            {
                var output = MapPassiveSkill(characterClass, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private SkillCharacterPassive MapPassiveSkill(CharacterClassIdentifier characterClass, CharacterSkillDto input)
        {
            return new SkillCharacterPassive
            {
                Id = new SkillIdentifier(characterClass, input.Slug),
                Name = input.Name,
                Level = input.Level,
                TooltipUrl = input.TooltipUrl,
                IconUrl = input.Icon,
                Category = SkillCategory.Passive
            };
        }
    }
}