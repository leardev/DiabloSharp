using System;
using System.Threading.Tasks;
using DiabloSharp.Configurations;
using DiabloSharp.Endpoints;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp
{
    public class DiabloApi : IDiabloApi
    {
        private readonly IDiabloApiConfiguration _configuration;

        private readonly IOAuthEndpoint _oAuth;

        public DiabloApi(IDiabloApiConfiguration configuration)
        {
            _configuration = configuration;

            var tokenBucket = new DefaultTokenBucket();
            _oAuth = new OAuthEndpoint(tokenBucket);
            Item = new ItemEndpoint(tokenBucket);
            Act = new ActEndpoint(tokenBucket);
            Artisan = new ArtisanEndpoint(tokenBucket);
            Follower = new FollowerEndpoint(tokenBucket);
            Character = new CharacterEndpoint(tokenBucket);
            Profile = new ProfileEndpoint(tokenBucket);
            Season = new SeasonEndpoint(tokenBucket);
        }

        public IItemEndpoint Item { get; }

        public IActEndpoint Act { get; }

        public IArtisanEndpoint Artisan { get; }

        public IFollowerEndpoint Follower { get; }

        public ICharacterEndpoint Character { get; }

        public IProfileEndpoint Profile { get; }

        public ISeasonEndpoint Season { get; }

        public async Task<IAuthenticationScope> CreateAuthenticationScopeAsync()
        {
            var authToken = await _oAuth.GetTokenAsync(_configuration.ClientId, _configuration.ClientSecret, _configuration.Region);
            var expirationDate = DateTime.Now.AddSeconds(authToken.SecondsUntilExpiration);

            return new AuthenticationScope
            {
                AccessToken = authToken.AccessToken,
                Localization = _configuration.Localization,
                Region = _configuration.Region,
                ExpirationDate = expirationDate
            };
        }
    }
}