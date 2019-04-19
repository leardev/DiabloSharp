using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Configurations;
using DiabloSharp.Extensions;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class OAuthClientTests
    {
        [Test]
        public async Task GetTokenAsyncTest()
        {
            var configuration = new DiabloApiEnvironmentConfiguration();
            using (var client = new OAuthClient(configuration.ClientId, configuration.ClientSecret, configuration.Region.ToDescription()))
            {
                var token = await client.GetTokenAsync();
                Assert.That(token.AccessToken, Is.Not.Null.Or.Empty);
                Assert.That(token.Type, Is.Not.Null.Or.Empty);
                Assert.NotZero(token.SecondsUntilExpiration);
            }
        }
    }
}