using System;

namespace DiabloSharp.Models
{
    public class AuthenticationScope
    {
        public AuthenticationScope(string accessToken, Localization localization, Region region,
            DateTime expirationDate)
        {
            AccessToken = accessToken;
            Localization = localization;
            Region = region;
            ExpirationDate = expirationDate;
        }

        public DateTime ExpirationDate { get; }

        public string AccessToken { get; }

        public Localization Localization { get; }

        public Region Region { get; }

        public bool IsExpired()
        {
            return DateTime.Now > ExpirationDate;
        }
    }
}