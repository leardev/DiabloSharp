using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class CharacterConverter
    {
        public CharacterClass CharacterToModel(CharacterClassIdentifier characterClassId, CharacterClassDto characterClass, IEnumerable<CharacterApiSkillDto> activeCharacterSkills)
        {
            var namesByGender = NamesToModel(characterClass);
            var activeSkills = activeCharacterSkills.Select(ActiveSkillToModel);
            var passiveSkills = characterClass.Skills.Passives.Select(PassiveSkillToModel);

            return new CharacterClass
            {
                Id = characterClassId,
                Name = characterClass.Name,
                IconUrl = characterClass.Icon,
                ActiveSkills = activeSkills,
                PassiveSkills = passiveSkills,
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

        private SkillCharacterActive ActiveSkillToModel(CharacterApiSkillDto characterApiSkillDto)
        {
            var runes = characterApiSkillDto.Runes.Select(RuneToModel);
            var skill = SkillToModel<SkillCharacterActive>(characterApiSkillDto.Skill);
            skill.Runes = runes;
            skill.Category = SkillCategory.Active;
            return skill;
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

        private SkillCharacterPassive PassiveSkillToModel(CharacterSkillDto characterSkillDto)
        {
            var skill = SkillToModel<SkillCharacterPassive>(characterSkillDto);
            skill.Category = SkillCategory.Passive;
            return skill;
        }

        private T SkillToModel<T>(CharacterSkillDto characterSkillDto) where T: SkillBase, new()
        {
            var tooltip = new Tooltip
            {
                Description = characterSkillDto.Description,
                DescriptionHtml = characterSkillDto.DescriptionHtml,
                FlavorText = characterSkillDto.FlavorText,
                Url = characterSkillDto.TooltipUrl,
                IconUrl = characterSkillDto.Icon
            };

            return new T
            {
                Id = characterSkillDto.Slug,
                Name = characterSkillDto.Name,
                Level = characterSkillDto.Level,
                Tooltip = tooltip
            };
        }
    }
}