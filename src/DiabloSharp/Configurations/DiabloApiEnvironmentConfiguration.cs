using DiabloSharp.Exceptions;
using DiabloSharp.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace DiabloSharp.Configurations
{
    public class DiabloApiEnvironmentConfiguration : IDiabloApiConfiguration
    {
        private const string EnvironmentVariablePrefix = "DiabloSharp";

        public string ClientId { get; }

        public string ClientSecret { get; }

        public Region Region { get; }

        public Localization Localization { get; }

        public DiabloApiEnvironmentConfiguration()
        {
            var builder = new ConfigurationBuilder();
            var configuration = builder.AddEnvironmentVariables("DiabloSharp")
                .Build();

            ClientId = configuration["ClientId"];
            if (string.IsNullOrEmpty(ClientId))
                throw new EnvironmentVariableNotFoundException($"{EnvironmentVariablePrefix}{nameof(ClientId)}");

            ClientSecret = configuration["ClientSecret"];
            if (string.IsNullOrEmpty(ClientSecret))
                throw new EnvironmentVariableNotFoundException($"{EnvironmentVariablePrefix}{nameof(ClientSecret)}");

            if (!Enum.TryParse<Region>(configuration["Region"], out var region))
                throw new EnvironmentVariableNotFoundException($"{EnvironmentVariablePrefix}{nameof(Region)}");
            Region = region;

            if (!Enum.TryParse<Localization>(configuration["Localization"], out var localization))
                throw new EnvironmentVariableNotFoundException($"{EnvironmentVariablePrefix}{nameof(Localization)}");
            Localization = localization;
        }
    }
}
