using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class OAuthTokenDto
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "token_type")]
        public string Type { get; set; }

        [DataMember(Name = "expires_in")]
        public long SecondsUntilExpiration { get; set; }
    }
}