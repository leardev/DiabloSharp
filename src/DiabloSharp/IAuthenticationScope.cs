using System;
using DiabloSharp.Models;

namespace DiabloSharp
{
    public interface IAuthenticationScope
    {
        DateTime ExpirationDate { get; }

        string AccessToken { get; }

        Localization Localization { get; }

        Region Region { get; }

        bool IsExpired();
    }
}