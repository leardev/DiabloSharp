namespace DiabloSharp.Clients
{
    internal class BattleNetClient : HttpClientBase
    {
        public BattleNetClient(string accessToken, string region, string localization) : base($"https://{region}.api.blizzard.com")
        {
            AddParameter("access_token", accessToken);
            AddParameter("locale", localization);
        }
    }
}