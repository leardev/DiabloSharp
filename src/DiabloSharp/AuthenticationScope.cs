using System;
using DiabloSharp.Models;

namespace DiabloSharp
{
    internal class AuthenticationScope : IAuthenticationScope
    {
        public DateTime ExpirationDate { get; set; }

        public string AccessToken { get; set; }

        public Localization Localization { get; set; }

        public Region Region { get; set; }

        public bool IsExpired()
        {
            return DateTime.Now > ExpirationDate;
        }
    }
}