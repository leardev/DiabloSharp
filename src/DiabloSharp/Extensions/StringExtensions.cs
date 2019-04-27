using System;
using DiabloSharp.Models;

namespace DiabloSharp.Extensions
{
    internal static class StringExtensions
    {
        public static ItemIdentifier ToItemIdentifier(this string value)
        {
            var pathIndex = value.IndexOf("/", StringComparison.Ordinal);
            var slugIndex = value.LastIndexOf("-", StringComparison.Ordinal);
            var slug = value.Substring(pathIndex + 1, slugIndex - pathIndex - 1);
            var id = value.Substring(slugIndex + 1, value.Length - slugIndex - 1);
            return new ItemIdentifier(id, slug);
        }
    }
}