using DiabloSharp.Endpoints;
using System.Threading.Tasks;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        Task<IAuthenticationScope> CreateAuthenticationScopeAsync();

        ItemTypeEndpoint ItemType { get; }

        ItemEndpoint Item { get; }

        ActEndpoint Act { get; }

        ArtisanEndpoint Artisan { get; }

        FollowerEndpoint Follower { get; }

        CharacterEndpoint Character { get; }

        ProfileEndpoint Profile { get; }

        SeasonEndpoint Season { get; }

        EraEndpoint Era { get; }
    }
}