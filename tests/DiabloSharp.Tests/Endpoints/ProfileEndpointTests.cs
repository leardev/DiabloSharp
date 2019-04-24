using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ProfileEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetAccountTest()
        {
            var battleTagId = new BattleTagIdentifier("Shanyen#2754");
            var account = await DiabloApi.Profile.GetAccountAsync(AuthenticationScope, battleTagId);
            Assert.IsNotNull(account);
        }
    }
}