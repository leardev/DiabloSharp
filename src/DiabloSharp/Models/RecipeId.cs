using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class RecipeId : ValueObject
    {
        public ArtisanId Id { get; }

        public string Slug { get; }

        public RecipeId(ArtisanId id, string slug)
        {
            Id = id;
            Slug = slug;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Slug;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Slug), Slug);
            return builder.ToString();
        }
    }
}