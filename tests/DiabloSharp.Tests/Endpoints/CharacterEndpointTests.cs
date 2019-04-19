using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class CharacterEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetCharacterClassTest()
        {
            var characterClass = await DiabloApi.Character.GetCharacterClassAsync(AuthenticationScope, CharacterClassIdentifier.Barbarian);
            Assert.IsNotNull(characterClass);
        }
    }
}