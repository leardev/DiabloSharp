using System;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Helpers
{
    internal static class ItemIdentifierHelper
    {
        public static ItemId FromItem(ItemIdentifierDto itemIdentifier)
        {
            if (IsObsolete(itemIdentifier))
                throw new Exception($"{itemIdentifier.Name} is obsolete");

            return FromString(itemIdentifier.TooltipParams);
        }

        public static ItemId FromItemOptional(ItemIdentifierDto itemIdentifier)
        {
            return itemIdentifier == null ? null : FromString(itemIdentifier.TooltipParams);
        }

        public static ItemId FromItemDyeOptional(ItemIdentifierDto itemIdentifier)
        {
            if (itemIdentifier == null)
                return null;

            /* BattleNet api returns invalid TooltipParams */
            var tooltipParams = $"{itemIdentifier.TooltipParams}-{itemIdentifier.Id}";
            return FromString(tooltipParams);
        }

        public static ItemId FromString(string value)
        {
            /* items (e.g. transmogs) from artisans return their recipes */
            if (value.Contains("artisan"))
                return null;

            var pathIndex = value.LastIndexOf("/", StringComparison.Ordinal);
            var slugIndex = value.LastIndexOf("-", StringComparison.Ordinal);
            var slug = value.Substring(pathIndex + 1, slugIndex - pathIndex - 1);
            var id = value.Substring(slugIndex + 1, value.Length - slugIndex - 1);
            return new ItemId(slug, id);
        }

        public static bool IsObsolete(ItemIdentifierDto itemIdentifier)
        {
            /* obsolete items have no TooltipParams (e.g. items that are not updated after the patch that must be looted again) */
            return string.IsNullOrEmpty(itemIdentifier.TooltipParams);
        }
    }
}