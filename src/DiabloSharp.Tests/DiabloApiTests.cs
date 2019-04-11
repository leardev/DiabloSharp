using System;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests
{
    [TestClass]
    public class DiabloApiTests
    {
        [TestMethod]
        public void CreateAuthenticationScopeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            Assert.IsTrue(DateTime.Now < authenticationScope.ExpirationDate);
            Assert.IsFalse(string.IsNullOrEmpty(authenticationScope.AccessToken));
            Assert.IsFalse(authenticationScope.IsExpired());
        }
    }
}