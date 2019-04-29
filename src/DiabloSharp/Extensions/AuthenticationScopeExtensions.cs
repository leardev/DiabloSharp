using System;
using DiabloSharp.Exceptions;
using DiabloSharp.Models;

namespace DiabloSharp.Extensions
{
    internal static class AuthenticationScopeExtensions
    {
        public static bool IsExpired(this IAuthenticationScope authenticationScope)
        {
            return DateTime.Now > authenticationScope.ExpirationDate;
        }

        public static void EnsureExpiration(this IAuthenticationScope authenticationScope)
        {
            if (authenticationScope.IsExpired())
                throw new DiabloApiAuthenticationExpiredException();
        }
    }
}