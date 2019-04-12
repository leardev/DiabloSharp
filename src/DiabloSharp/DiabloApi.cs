using System;
using DiabloSharp.Configurations;
using DiabloSharp.Endpoints;

namespace DiabloSharp
{
    public class DiabloApi : IDiabloApi
    {
        private readonly IDiabloApiConfiguration _configuration;

        private readonly OAuthEndpoint _oAuth;

        public DiabloApi(IDiabloApiConfiguration configuration)
        {
            _configuration = configuration;
            _oAuth = new OAuthEndpoint();
            ItemType = new ItemTypeEndpoint();
            Item = new ItemEndpoint();
        }

        public ItemTypeEndpoint ItemType { get; }

        public ItemEndpoint Item { get; }

        public IAuthenticationScope CreateAuthenticationScope()
        {
            var authToken = _oAuth.GetToken(_configuration.ClientId, _configuration.ClientSecret, _configuration.Region);
            var expirationDate = DateTime.Now.AddSeconds(authToken.SecondsUntilExpiration);

            return new AuthenticationScope
            {
                AccessToken = authToken.AccessToken,
                ExpirationDate = expirationDate,
                Localization = _configuration.Localization,
                Region = _configuration.Region
            };
        }
    }
}