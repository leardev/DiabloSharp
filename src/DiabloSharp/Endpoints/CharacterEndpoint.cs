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
        public CharacterEndpoint(ITokenBucket tokenBucket)
            : base(tokenBucket)
        {
        }

        public Task<IEnumerable<CharacterKind>> GetCharacterKindsAsync()
        {
            var characterKinds = Enum.GetValues(typeof(CharacterKind))
                .Cast<CharacterKind>();
            return Task.FromResult(characterKinds);
        }

        public async Task<Character> GetCharacterAsync(IAuthenticationScope authenticationScope, CharacterKind characterKind)
        {
            var mapper = new CharacterMapper();
            var artisanSlug = EnumConversionHelper.CharacterIdentifierToString(characterKind);

            using (var client = CreateClient(authenticationScope))
            {
                var characterClass = await client.GetCharacterClassAsync(artisanSlug);

                /* GetApiSkill only extends active skills with runes, all the other properties are already retrieved via GetCharacterClass */
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

        public async Task<IEnumerable<Character>> GetCharactersAsync(IAuthenticationScope authenticationScope)
        {
            var characterKinds = await GetCharacterKindsAsync();

            var charactersTasks = characterKinds.Select(id => GetCharacterAsync(authenticationScope, id));
            var characters = await Task.WhenAll(charactersTasks);
            return characters;
        }
    }
}