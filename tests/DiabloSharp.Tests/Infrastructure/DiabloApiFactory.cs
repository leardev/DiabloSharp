using DiabloSharp.Configurations;

namespace DiabloSharp.Tests.Infrastructure
{
    internal static class DiabloApiFactory
    {
        public static IDiabloApi CreateApi()
        {
            var configuration = new DiabloApiEnvironmentConfiguration();
            return new DiabloApi(configuration);
        }
    }
}