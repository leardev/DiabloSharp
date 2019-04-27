using System.Threading.Tasks;
using DiabloSharp.Endpoints;
using DiabloSharp.Models;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        ItemEndpoint Item { get; }

        ActEndpoint Act { get; }

        ArtisanEndpoint Artisan { get; }

        FollowerEndpoint Follower { get; }

        CharacterEndpoint Character { get; }

        ProfileEndpoint Profile { get; }

        Task<AuthenticationScope> CreateAuthenticationScopeAsync();
    }
}