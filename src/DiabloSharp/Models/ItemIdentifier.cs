using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class ItemIdentifier : ValueObject
    {
        public ItemIdentifier(string id, string slug)
        {
            Id = id;
            Slug = slug;
        }

        public string Id { get; }

        public string Slug { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Slug;
        }

        public override string ToString()
        {
            return $"{Slug}-{Id}";
        }
    }
}