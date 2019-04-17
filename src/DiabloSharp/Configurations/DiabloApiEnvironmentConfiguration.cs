using System;
using DiabloSharp.Exceptions;
using DiabloSharp.Models;

namespace DiabloSharp.Configurations
{
    public class DiabloApiEnvironmentConfiguration : IDiabloApiConfiguration
    {
        private const string ClientIdEnvironmentKey = "DiabloSharpClientId";

        private const string ClientSecretEnvironmentKey = "DiabloSharpClientSecret";

        private const string RegionEnvironmentKey = "DiabloSharpRegion";

        private const string LocalizationEnvironmentKey = "DiabloSharpLocalization";

        public DiabloApiEnvironmentConfiguration()
        {
            ClientId = GetEnvironmentVariableThrowIfMissing(ClientIdEnvironmentKey);
            ClientSecret = GetEnvironmentVariableThrowIfMissing(ClientSecretEnvironmentKey);
            var regionValue = GetEnvironmentVariableThrowIfMissing(RegionEnvironmentKey);
            var localizationValue = GetEnvironmentVariableThrowIfMissing(LocalizationEnvironmentKey);

            if (!Enum.TryParse<Region>(regionValue, out var region))
                throw new DiabloApiException($"Unable to cast value of environment variable \"{RegionEnvironmentKey}\" to {typeof(Region).Name}.");

            if (!Enum.TryParse<Localization>(localizationValue, out var localization))
                throw new DiabloApiException($"Unable to cast value of environment variable \"{LocalizationEnvironmentKey}\" to {typeof(Localization).Name}.");

            Region = region;
            Localization = localization;
        }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public Region Region { get; }

        public Localization Localization { get; }

        private string GetEnvironmentVariableThrowIfMissing(string variable)
        {
            var value = Environment.GetEnvironmentVariable(variable);
            if (string.IsNullOrEmpty(value))
                throw new DiabloApiException($"Cannot find environment variable \"{variable}\".");
            return value;
        }
    }
}