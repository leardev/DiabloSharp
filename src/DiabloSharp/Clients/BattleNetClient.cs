using System.Threading.Tasks;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Clients
{
    internal class BattleNetClient : RestClient
    {
        private readonly IAuthenticationScope _authenticationScope;

        public BattleNetClient(IAuthenticationScope authenticationScope) : base($"https://{authenticationScope.Region.ToDescription()}.api.blizzard.com")
        {
            _authenticationScope = authenticationScope;
            AddHandler("application/json", () => new NewtonsoftJsonDeserializer());
        }

        public override IRestResponse Execute(IRestRequest request)
        {
            PrepareRequest(request);
            var response = base.Execute(request);
            return response;
        }

        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            PrepareRequest(request);
            var response = base.Execute<T>(request);
            return response;
        }

        public override Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            PrepareRequest(request);
            var response = base.ExecuteTaskAsync(request);
            return response;
        }

        public override Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            PrepareRequest(request);
            var response = base.ExecuteTaskAsync<T>(request);
            return response;
        }

        private void PrepareRequest(IRestRequest request)
        {
            _authenticationScope.EnsureExpiration();
            request.AddParameter("access_token", _authenticationScope.AccessToken, ParameterType.QueryString);
            request.AddParameter("locale", _authenticationScope.Localization.ToDescription(), ParameterType.QueryString);
        }
    }
}