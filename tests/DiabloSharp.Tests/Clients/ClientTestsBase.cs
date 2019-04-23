using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.RateLimiters;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    internal class ClientTestsBase
    {
        protected BattleNetClient Client { get; private set; }

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();
            Client = new BattleNetClient(authenticationScope.AccessToken, authenticationScope.Region.ToDescription(), authenticationScope.Localization.ToDescription(), new DefaultTokenBucket());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Client.Dispose();
        }
    }
}