using System;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests
{
    [TestFixture]
    public class DiabloApiTests
    {
        [Test]
        public async Task CreateAuthenticationScopeAsyncTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            Assert.IsTrue(DateTime.Now < authenticationScope.ExpirationDate);
            Assert.That(authenticationScope.AccessToken, Is.Not.Null.Or.Empty);
            Assert.IsFalse(authenticationScope.IsExpired());
        }
    }
}