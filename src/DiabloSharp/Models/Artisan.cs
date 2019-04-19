using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Artisan : ModelBase<ArtisanIdentifier>
    {
        public string Name { get; internal set; }

        public string Portrait { get; internal set; }

        public IEnumerable<RecipeArtisan> Recipes { get; internal set; }
    }
}