using DiabloSharp.Models;

namespace DiabloSharp.Configurations
{
    public interface IDiabloApiConfiguration
    {
        string ClientId { get; }

        string ClientSecret { get; }

        Region Region { get; }

        Localization Localization { get; }
    }
}