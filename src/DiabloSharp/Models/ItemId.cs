using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class ItemId : ValueObject
    {
        public ItemId(string slug, string id)
        {
            Slug = slug;
            Id = id;
        }

        public string Id { get; }

        public string Slug { get; }

        public override string ToString()
        {
            return $"{Slug}-{Id}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Slug;
        }
    }
}