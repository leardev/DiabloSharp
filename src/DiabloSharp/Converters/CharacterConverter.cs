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
            var names = NamesToModel(characterClass);
            var activeSkills = activeCharacterSkills
                .Select(dto => ActiveSkillToModel(characterClassId, dto))
                .ToList();

            var passiveSkills = characterClass.Skills.Passives
                .Select(dto => PassiveSkillToModel(characterClassId, dto))
                .ToList();

            var skills = activeSkills.Cast<SkillCharacter>().Concat(passiveSkills);

            return new CharacterClass
            {
                Id = characterClassId,
                Name = characterClass.Name,
                IconUrl = characterClass.Icon,
                ActiveSkills = activeSkills,
                PassiveSkills = passiveSkills,
                Skills = skills,
                Names = names
            };
        }

        private IEnumerable<CharacterName> NamesToModel(CharacterClassDto characterClass)
        {
            return new[]
            {
                new CharacterName { Id = Gender.Male, Name = characterClass.MaleName },
                new CharacterName { Id = Gender.Female, Name = characterClass.FemaleName }
            };
        }

        private SkillCharacterActive ActiveSkillToModel(CharacterClassIdentifier characterClass, CharacterApiSkillDto characterApiSkillDto)
        {
            var runes = characterApiSkillDto.Runes.Select(dto => RuneToModel(characterClass, dto));
            var skill = SkillToModel<SkillCharacterActive>(characterClass, characterApiSkillDto.Skill);
            skill.Runes = runes;
            skill.Category = SkillCategory.Active;
            return skill;
        }

        private SkillRune RuneToModel(CharacterClassIdentifier characterClass, CharacterRuneDto characterRuneDto)
        {
            return new SkillRune
            {
                Id = new SkillIdentifier(characterClass, characterRuneDto.Slug),
                Name = characterRuneDto.Name,
                Level = characterRuneDto.Level
            };
        }

        private SkillCharacterPassive PassiveSkillToModel(CharacterClassIdentifier characterClass, CharacterSkillDto characterSkillDto)
        {
            var skill = SkillToModel<SkillCharacterPassive>(characterClass, characterSkillDto);
            skill.Category = SkillCategory.Passive;
            return skill;
        }

        private T SkillToModel<T>(CharacterClassIdentifier characterClass, CharacterSkillDto characterSkillDto) where T : SkillCharacter, new()
        {
            return new T
            {
                Id = new SkillIdentifier(characterClass, characterSkillDto.Slug),
                Name = characterSkillDto.Name,
                Level = characterSkillDto.Level,
                TooltipUrl = characterSkillDto.TooltipUrl,
                IconUrl = characterSkillDto.Icon
            };
        }
    }
}