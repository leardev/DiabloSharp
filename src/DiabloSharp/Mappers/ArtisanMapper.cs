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
            var recipes = new List<RecipeArtisan>();
            foreach (var tier in input.Training.Tiers)
            {
                var rank = (RecipeRank)tier.Index;
                var taughtRecipes = MapRecipes(rank, RecipeSource.Taught, tier.TaughtRecipes);
                var trainedRecipes = MapRecipes(rank, RecipeSource.Trained, tier.TrainedRecipes);
                recipes.AddRange(taughtRecipes);
                recipes.AddRange(trainedRecipes);
            }

            output.Id = EnumConversionHelper.ArtisanIdentifierFromString(input.Slug);
            output.Name = input.Name;
            output.Portrait = input.Portrait;
            output.Recipes = recipes;
        }

        private IEnumerable<RecipeArtisan> MapRecipes(RecipeRank rank, RecipeSource source, IEnumerable<ArtisanRecipeDto> inputs)
        {
            var outputs = new List<RecipeArtisan>();
            foreach (var input in inputs)
            {
                var output = MapRecipe(rank, source, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private RecipeArtisan MapRecipe(RecipeRank rank, RecipeSource source, ArtisanRecipeDto input)
        {
            var reagents = MapReagents(input.Reagents);

            return new RecipeArtisan
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
                ItemId = new ItemIdentifier(input.Item.Slug, input.Item.Id)
            };
        }
    }
}