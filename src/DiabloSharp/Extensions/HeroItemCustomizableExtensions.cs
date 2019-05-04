using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.Models;

namespace DiabloSharp.Extensions
{
    internal static class HeroItemCustomizableExtensions
    {
        public static bool TryGetAttribute<T>(this HeroItemCustomizable item, out T attribute) where T : IHeroItemAttribute
        {
            var result = item.TryGetAttributes<T>(out var attributes);
            attribute = result ? attributes.First() : default;
            return result;
        }

        public static T GetAttribute<T>(this HeroItemCustomizable item) where T : IHeroItemAttribute
        {
            if (!item.TryGetAttribute<T>(out var attribute))
                throw new Exception($"Unable to resolve attribute for type {typeof(T).Name}.");
            return attribute;
        }

        public static IEnumerable<T> GetAttributes<T>(this HeroItemCustomizable item) where T : IHeroItemAttribute
        {
            if (!item.TryGetAttributes<T>(out var attributes))
                throw new Exception($"Unable to resolve attributes for type {typeof(T).Name}.");
            return attributes;
        }

        public static bool TryGetAttributes<T>(this HeroItemCustomizable item, out IEnumerable<T> attributes) where T: IHeroItemAttribute
        {
            attributes = item.Attributes.Where(attribute => attribute.GetType() == typeof(T))
                .Cast<T>()
                .ToList();
            attributes = attributes.Any() ? attributes : null;
            return attributes != null;
        }
    }
}