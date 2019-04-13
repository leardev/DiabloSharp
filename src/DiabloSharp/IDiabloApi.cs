using DiabloSharp.Endpoints;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        IAuthenticationScope CreateAuthenticationScope();

        ItemTypeEndpoint ItemType { get; }

        ItemEndpoint Item { get; }

        ActEndpoint Act { get; }

        ArtisanEndpoint Artisan { get; }

        FollowerEndpoint Follower { get; }

        HeroEndpoint Hero { get; }

        ProfileEndpoint Profile { get; }

        EraEndpoint Era { get; }
    }
}