using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Helpers;
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

            var regionString = EnumConversionHelper.RegionToString(authenticationScope.Region);
            var localizationString = EnumConversionHelper.LocalizationToString(authenticationScope.Localization);

            Client = new BattleNetClient(authenticationScope.AccessToken, regionString, localizationString, new DefaultTokenBucket());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Client.Dispose();
        }
    }
}