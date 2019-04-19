using System;
using DiabloSharp.Models;

namespace DiabloSharp.Extensions
{
    internal static class AuthenticationScopeExtensions
    {
        public static void EnsureExpiration(this AuthenticationScope authenticationScope)
        {
            if (authenticationScope.IsExpired())
                throw new Exception("Authentication scope is expired.");
        }
    }
}