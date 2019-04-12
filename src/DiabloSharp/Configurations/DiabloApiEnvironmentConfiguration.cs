using DiabloSharp.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace DiabloSharp.Configurations
{
    public class DiabloApiEnvironmentConfiguration : IDiabloApiConfiguration
    {
        public string ClientId { get; }

        public string ClientSecret { get; }

        public Region Region { get; }

        public Localization Localization { get; }

        public DiabloApiEnvironmentConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables("DiabloSharp");
            var configuration = builder.Build();

            ClientId = configuration["ClientId"];
            if (string.IsNullOrEmpty(ClientId))
                throw new Exception($"Cannot read required {nameof(ClientId)} from environment variables!");

            ClientSecret = configuration["ClientSecret"];
            if (string.IsNullOrEmpty(ClientSecret))
                throw new Exception($"Cannot read required {nameof(ClientSecret)} from environment variables!");

            if (!Enum.TryParse<Region>(configuration["Region"], out var region))
                throw new Exception($"Cannot read required {nameof(Region)} from environment variables!");
            Region = region;

            if (!Enum.TryParse<Localization>(configuration["Localization"], out var localization))
                throw new Exception($"Cannot read required {nameof(Localization)} from environment variables!");
            Localization = localization;
        }
    }
}
