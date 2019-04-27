namespace DiabloSharp.Models
{
    internal class OAuthToken : ModelBase
    {
        public string AccessToken { get; internal set; }

        public long SecondsUntilExpiration { get; internal set; }
    }
}