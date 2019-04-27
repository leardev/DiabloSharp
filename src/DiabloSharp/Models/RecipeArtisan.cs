namespace DiabloSharp.Models
{
    public class RecipeArtisan : Recipe
    {
        public RecipeRank Rank { get; internal set; }

        public RecipeSource Source { get; internal set; }
    }
}