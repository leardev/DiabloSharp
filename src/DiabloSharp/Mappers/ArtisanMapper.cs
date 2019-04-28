using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class ArtisanMapper : Mapper<ArtisanDto, Artisan>
    {
        protected override void Map(ArtisanDto input, Artisan output)
        {
            var recipes = new List<ArtisanRecipe>();
            foreach (var tier in input.Training.Tiers)
            {
                var rank = (ArtisanRecipeRank)tier.Index;
                var taughtRecipes = MapRecipes(rank, ArtisanRecipeSource.Taught, tier.TaughtRecipes);
                var trainedRecipes = MapRecipes(rank, ArtisanRecipeSource.Trained, tier.TrainedRecipes);
                recipes.AddRange(taughtRecipes);
                recipes.AddRange(trainedRecipes);
            }

            output.Id = EnumConversionHelper.ArtisanIdentifierFromString(input.Slug);
            output.Name = input.Name;
            output.Portrait = input.Portrait;
            output.Recipes = recipes;
        }

        private IEnumerable<ArtisanRecipe> MapRecipes(ArtisanRecipeRank rank, ArtisanRecipeSource source, IEnumerable<ArtisanRecipeDto> inputs)
        {
            var outputs = new List<ArtisanRecipe>();
            foreach (var input in inputs)
            {
                var output = MapRecipe(rank, source, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private ArtisanRecipe MapRecipe(ArtisanRecipeRank rank, ArtisanRecipeSource source, ArtisanRecipeDto input)
        {
            var reagents = MapReagents(input.Reagents);

            return new ArtisanRecipe
            {
                Id = new ItemIdentifier(input.Slug, input.Id),
                Name = input.Name,
                Cost = input.Cost,
                Rank = rank,
                Source = source,
                Reagents = reagents,
                CraftedItemId = new ItemIdentifier(input.ItemProduced.Slug, input.ItemProduced.Id)
            };
        }

        private IEnumerable<RecipeReagent> MapReagents(IEnumerable<ArtisanReagentDto> inputs)
        {
            var outputs = new List<RecipeReagent>();
            foreach (var input in inputs)
            {
                var output = MapReagent(input);
                outputs.Add(output);
            }

            return outputs;
        }

        private RecipeReagent MapReagent(ArtisanReagentDto input)
        {
            return new RecipeReagent
            {
                Quantity = input.Quantity,
                Id = new ItemIdentifier(input.Item.Slug, input.Item.Id)
            };
        }
    }
}