namespace DiabloSharp.Models
{
    public class ArtisanRecipe : Recipe
    {
        public ArtisanRecipeRank Rank { get; internal set; }

        public ArtisanRecipeSource Source { get; internal set; }
    }
}