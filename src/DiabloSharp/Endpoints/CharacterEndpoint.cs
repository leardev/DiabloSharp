using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Converters;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class CharacterEndpoint : Endpoint,
                                       ICharacterEndpoint
    {
        private readonly CharacterConverter _characterConverter;

        public CharacterEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
            _characterConverter = new CharacterConverter();
        }

        public async Task<CharacterClass> GetCharacterClassAsync(IAuthenticationScope authenticationScope, CharacterClassIdentifier characterClassId)
        {
            var artisanSlug = characterClassId.ToDescription();

            using (var client = CreateClient(authenticationScope))
            {
                var characterClass = await client.GetCharacterClassAsync(artisanSlug);

                var activeApiSkills = new List<CharacterApiSkillDto>();
                foreach (var skill in characterClass.Skills.Actives)
                {
                    var apiSkill = await client.GetApiSkillAsync(artisanSlug, skill.Slug);
                    activeApiSkills.Add(apiSkill);
                }

                return _characterConverter.CharacterToModel(characterClassId, characterClass, activeApiSkills);
            }
        }
    }
}