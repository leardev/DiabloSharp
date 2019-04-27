using System.Threading.Tasks;
using DiabloSharp.Models;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    public class EndpointTestsBase
    {
        protected IDiabloApi DiabloApi { get; private set; }

        protected IAuthenticationScope AuthenticationScope { get; private set; }

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            DiabloApi = DiabloApiFactory.CreateApi();
            AuthenticationScope = await DiabloApi.CreateAuthenticationScopeAsync();
        }
    }
}