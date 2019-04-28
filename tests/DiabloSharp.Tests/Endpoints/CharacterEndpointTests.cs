using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class CharacterEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetCharacterTest()
        {
            var character = await DiabloApi.Character.GetCharacterAsync(AuthenticationScope, CharacterIdentifier.Barbarian);
            Assert.IsNotNull(character);
        }
    }
}