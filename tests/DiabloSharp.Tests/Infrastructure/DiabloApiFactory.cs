using DiabloSharp.Configurations;
using DiabloSharp.Models;
using Microsoft.Extensions.Configuration;

namespace DiabloSharp.Tests.Infrastructure
{
    internal class DiabloApiFactory
    {
        public static IDiabloApi CreateApi()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<BattleNetApiCredentials>();
            var secretsConfiguration = builder.Build();

            var configuration = new DiabloApiConfiguration
            {
                ClientId = secretsConfiguration["BattleNetApiCredentials:ClientId"],
                ClientSecret = secretsConfiguration["BattleNetApiCredentials:ClientSecret"],
                Region = Region.Europe,
                Localization = Localization.EnglishUs
            };
            return new DiabloApi(configuration);
        }
    }
}