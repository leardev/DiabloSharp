using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class CharacterEndpoint : Endpoint,
                                       ICharacterEndpoint
    {
        public CharacterEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<CharacterClass> GetCharacterClassAsync(IAuthenticationScope authenticationScope, CharacterClassIdentifier characterClassId)
        {
            var mapper = new CharacterClassMapper();
            var artisanSlug = EnumConversionHelper.CharacterClassIdentifierToString(characterClassId);

            using (var client = CreateClient(authenticationScope))
            {
                var characterClass = await client.GetCharacterClassAsync(artisanSlug);

                var activeApiSkills = new List<CharacterApiSkillDto>();
                foreach (var skill in characterClass.Skills.Actives)
                {
                    var apiSkill = await client.GetApiSkillAsync(artisanSlug, skill.Slug);
                    activeApiSkills.Add(apiSkill);
                }

                mapper.Actives = activeApiSkills;
                return mapper.Map(characterClass);
            }
        }

        public async Task<IEnumerable<CharacterClass>> GetCharacterClassesAsync(IAuthenticationScope authenticationScope)
        {
            var characterClassIds = Enum.GetValues(typeof(CharacterClassIdentifier))
                .Cast<CharacterClassIdentifier>()
                .ToList();

            var characterClassTasks = characterClassIds.Select(id => GetCharacterClassAsync(authenticationScope, id));
            var characterClasses = await Task.WhenAll(characterClassTasks);
            return characterClasses;
        }
    }
}