using System;

namespace DiabloSharp.Models
{
    public interface IAuthenticationScope
    {
        DateTime ExpirationDate { get; }

        string AccessToken { get; }

        Localization Localization { get; }

        Region Region { get; }
    }
}