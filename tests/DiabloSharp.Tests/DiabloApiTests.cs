using System;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests
{
    [TestFixture]
    public class DiabloApiTests
    {
        [Test]
        public void CreateAuthenticationScopeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            Assert.IsTrue(DateTime.Now < authenticationScope.ExpirationDate);
            Assert.IsNotEmpty(authenticationScope.AccessToken);
            Assert.IsFalse(authenticationScope.IsExpired());
        }
    }
}