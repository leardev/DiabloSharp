using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Artisan : ModelBase<ArtisanIdentifier>
    {
        public Artisan(ArtisanIdentifier id, string name, string portrait, IEnumerable<RecipeArtisan> recipes) : base(id)
        {
            Name = name;
            Portrait = portrait;
            Recipes = recipes;
        }

        public string Name { get; }

        public string Portrait { get; }

        public IEnumerable<RecipeArtisan> Recipes { get; }
    }
}