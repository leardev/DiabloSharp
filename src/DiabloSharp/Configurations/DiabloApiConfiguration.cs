using DiabloSharp.Models;

namespace DiabloSharp.Configurations
{
    public class DiabloApiConfiguration : IDiabloApiConfiguration
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Region Region { get; set; }

        public Localization Localization { get; set; }
    }
}