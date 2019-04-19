using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class CharacterConverter
    {
        public CharacterClass CharacterToModel(CharacterClassIdentifier characterClassId, CharacterClassDto characterClass, IEnumerable<CharacterApiSkillDto> activeSkills)
        {
            var namesByGender = NamesToModel(characterClass);
            var skills = SkillsToModel(characterClass, activeSkills);

            return new CharacterClass
            {
                Id = characterClassId,
                Name = characterClass.Name,
                IconUrl = characterClass.Icon,
                Skills = skills,
                NamesByGender = namesByGender
            };
        }

        private IDictionary<Gender, string> NamesToModel(CharacterClassDto characterClass)
        {
            return new Dictionary<Gender, string>
            {
                { Gender.Male, characterClass.MaleName },
                { Gender.Female, characterClass.FemaleName }
            };
        }

        private IEnumerable<Skill> SkillsToModel(CharacterClassDto characterClass, IEnumerable<CharacterApiSkillDto> activeCharacterSkills)
        {
            var skills = new List<Skill>();

            var passiveSkills = characterClass.Skills.Passives.Select(dto => SkillToModel(SkillCategory.Passive, dto, new List<SkillRune>()));
            var activeSkills = activeCharacterSkills.Select(ActiveSkillToModel);
            skills.AddRange(passiveSkills);
            skills.AddRange(activeSkills);
            return skills;
        }

        private Skill ActiveSkillToModel(CharacterApiSkillDto characterApiSkillDto)
        {
            var runes = characterApiSkillDto.Runes.Select(RuneToModel);
            return SkillToModel(SkillCategory.Active, characterApiSkillDto.Skill, runes);
        }

        private SkillRune RuneToModel(CharacterRuneDto characterRuneDto)
        {
            var tooltip = new Tooltip
            {
                Description = characterRuneDto.Description,
                DescriptionHtml = characterRuneDto.DescriptionHtml
            };

            return new SkillRune
            {
                Id = characterRuneDto.Slug,
                Name = characterRuneDto.Name,
                Level = characterRuneDto.Level,
                Tooltip = tooltip
            };
        }

        private Skill SkillToModel(SkillCategory skillCategory, CharacterSkillDto characterSkillDto, IEnumerable<SkillRune> runes)
        {
            var tooltip = new Tooltip
            {
                Description = characterSkillDto.Description,
                DescriptionHtml = characterSkillDto.DescriptionHtml,
                FlavorText = characterSkillDto.FlavorText,
                Url = characterSkillDto.TooltipUrl,
                IconUrl = characterSkillDto.Icon
            };

            return new Skill
            {
                Id = characterSkillDto.Slug,
                Name = characterSkillDto.Name,
                Level = characterSkillDto.Level,
                Category = skillCategory,
                Tooltip = tooltip,
                Runes = runes
            };
        }
    }
}