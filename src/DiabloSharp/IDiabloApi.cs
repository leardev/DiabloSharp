using System.Threading.Tasks;
using DiabloSharp.Endpoints;
using DiabloSharp.Models;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        IItemEndpoint Item { get; }

        IActEndpoint Act { get; }

        IArtisanEndpoint Artisan { get; }

        IFollowerEndpoint Follower { get; }

        ICharacterEndpoint Character { get; }

        IProfileEndpoint Profile { get; }

        Task<AuthenticationScope> CreateAuthenticationScopeAsync();
    }
}