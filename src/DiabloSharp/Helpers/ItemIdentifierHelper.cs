using System;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Helpers
{
    internal static class ItemIdentifierHelper
    {
        public static ItemIdentifier FromItem(HeroItemDto input)
        {
            return FromString(input.TooltipParams);
        }

        public static ItemIdentifier FromItem(HeroItemDyeDto input)
        {
            return input == null ? null : FromString(input.TooltipParams);
        }

        public static ItemIdentifier FromItem(HeroItemTransmogDto input)
        {
            return input == null ? null : FromString(input.TooltipParams);
        }

        public static ItemIdentifier FromString(string value)
        {
            var pathIndex = value.IndexOf("/", StringComparison.Ordinal);
            var slugIndex = value.LastIndexOf("-", StringComparison.Ordinal);
            var slug = value.Substring(pathIndex + 1, slugIndex - pathIndex - 1);
            var id = value.Substring(slugIndex + 1, value.Length - slugIndex - 1);
            return new ItemIdentifier(slug, id);
        }
    }
}