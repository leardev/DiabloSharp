using System;

namespace DiabloSharp.Extensions
{
    internal static class AuthenticationScopeExtensions
    {
        public static void EnsureExpiration(this IAuthenticationScope authenticationScope)
        {
            if (authenticationScope.IsExpired())
                throw new Exception("Authentication scope is expired.");
        }
    }
}