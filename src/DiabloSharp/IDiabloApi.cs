using DiabloSharp.Endpoints;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        Task<AuthenticationScope> CreateAuthenticationScopeAsync();

        ItemEndpoint Item { get; }

        GemEndpoint Gem { get; }

        ActEndpoint Act { get; }

        ArtisanEndpoint Artisan { get; }

        FollowerEndpoint Follower { get; }

        CharacterEndpoint Character { get; }

        ProfileEndpoint Profile { get; }

        SeasonEndpoint Season { get; }

        EraEndpoint Era { get; }
    }
}