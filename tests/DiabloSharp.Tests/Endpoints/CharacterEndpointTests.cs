using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class CharacterEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetCharacterKindsTest()
        {
            var characterKinds = await DiabloApi.Character.GetCharacterKindsAsync();
            Assert.IsNotEmpty(characterKinds);
        }

        [Test]
        public async Task GetCharactersTest()
        {
            var characters = await DiabloApi.Character.GetCharactersAsync(AuthenticationScope);
            Assert.IsNotEmpty(characters);
        }

        [Test]
        public async Task GetCharacterTest()
        {
            var character = await DiabloApi.Character.GetCharacterAsync(AuthenticationScope, CharacterKind.Barbarian);
            Assert.IsNotNull(character);
        }
    }
}