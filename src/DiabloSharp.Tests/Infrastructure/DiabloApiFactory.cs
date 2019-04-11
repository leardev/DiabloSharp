using DiabloSharp.Configurations;
using DiabloSharp.Models;

namespace DiabloSharp.Tests.Infrastructure
{
    internal class DiabloApiFactory
    {
        private const string ClientId = "";

        private const string ClientSecret = "";

        public static IDiabloApi CreateApi()
        {
            var configuration = new DiabloApiConfiguration
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Region = Region.Europe,
                Localization = Localization.EnglishUs
            };
            return new DiabloApi(configuration);
        }
    }
}