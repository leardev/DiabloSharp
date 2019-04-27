using System;

namespace DiabloSharp.Models
{
    internal class AuthenticationScope : IAuthenticationScope
    {
        public DateTime ExpirationDate { get; internal set; }

        public string AccessToken { get; internal set; }

        public Localization Localization { get; internal set; }

        public Region Region { get; internal set; }
    }
}