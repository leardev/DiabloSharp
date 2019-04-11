using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    internal class OAuthToken
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "token_type")]
        public string Type { get; set; }

        [DataMember(Name = "expires_in")]
        public int SecondsUntilExpiration { get; set; }
    }
}