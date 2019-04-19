using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class RecipeArtisan : Recipe
    {
        public RecipeArtisan(string id, string slug, string name, long cost, ItemIdentifier craftedItemId, IEnumerable<RecipeReagent> reagents, RecipeRank rank, RecipeSource source) : base(id, slug, name, cost, craftedItemId, reagents)
        {
            Rank = rank;
            Source = source;
        }

        public RecipeRank Rank { get; }

        public RecipeSource Source { get; }
    }
}