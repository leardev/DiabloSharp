using System;
using System.Threading.Tasks;
using DiabloSharp.Configurations;
using DiabloSharp.Endpoints;
using DiabloSharp.Models;

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
            Item = new ItemEndpoint();
            Gem = new GemEndpoint();
            Act = new ActEndpoint();
            Artisan = new ArtisanEndpoint();
            Follower = new FollowerEndpoint();
            Character = new CharacterEndpoint();
            Profile = new ProfileEndpoint();
            Season = new SeasonEndpoint();
            Era = new EraEndpoint();
        }

        public ItemEndpoint Item { get; }

        public GemEndpoint Gem { get; }

        public ActEndpoint Act { get; }

        public ArtisanEndpoint Artisan { get; }

        public FollowerEndpoint Follower { get; }

        public CharacterEndpoint Character { get; }

        public ProfileEndpoint Profile { get; }

        public SeasonEndpoint Season { get; }

        public EraEndpoint Era { get; }

        public async Task<AuthenticationScope> CreateAuthenticationScopeAsync()
        {
            var authToken = await _oAuth.GetTokenAsync(_configuration.ClientId, _configuration.ClientSecret, _configuration.Region);
            var expirationDate = DateTime.Now.AddSeconds(authToken.SecondsUntilExpiration);

            return new AuthenticationScope(authToken.AccessToken, _configuration.Localization, _configuration.Region,
                expirationDate);
        }
    }
}