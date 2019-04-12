using DiabloSharp.Endpoints;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        IAuthenticationScope CreateAuthenticationScope();

        ItemTypeEndpoint ItemType { get; }

        ItemEndpoint Item { get; }

        ArtisianEndpoint Artisian { get; }
    }
}