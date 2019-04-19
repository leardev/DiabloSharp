using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ArtisanConverter
    {
        public Artisan ArtisanToModel(ArtisanDto artisanDto)
        {
            Enum.TryParse<ArtisanIdentifier>(artisanDto.Slug, true, out var artisanId);
            var recipes = TrainingToModel(artisanDto.Training);

            return new Artisan
            {
                Id = artisanId,
                Name = artisanDto.Name,
                Portrait = artisanDto.Portrait,
                Recipes = recipes
            };
        }

        public Recipe RecipeToModel(ArtisanRecipeDto recipeDto)
        {
            var craftedItemId = ItemToModel(recipeDto.ItemProduced);
            var reagents = recipeDto.Reagents.Select(ReagentToModel);

            return new Recipe
            {
                Id = new ItemIdentifier(recipeDto.Id, recipeDto.Slug),
                Name = recipeDto.Name,
                Cost = recipeDto.Cost,
                Reagents = reagents,
                CraftedItemId = craftedItemId
            };
        }

        private IEnumerable<RecipeArtisan> TrainingToModel(ArtisanTrainingDto artisanTrainingDto)
        {
            var recipes = new List<RecipeArtisan>();
            foreach (var artisanTierDto in artisanTrainingDto.Tiers)
            {
                var recipeRank = (RecipeRank) artisanTierDto.Index;
                var trainedRecipes = artisanTierDto.TrainedRecipes.Select(dto => ArtisanRecipeToModel(dto, recipeRank, RecipeSource.Trained));
                recipes.AddRange(trainedRecipes);

                var taughtRecipes = artisanTierDto.TaughtRecipes.Select(dto => ArtisanRecipeToModel(dto, recipeRank, RecipeSource.Taught));
                recipes.AddRange(taughtRecipes);
            }
            return recipes;
        }

        private RecipeArtisan ArtisanRecipeToModel(ArtisanRecipeDto recipeDto, RecipeRank recipeRank, RecipeSource source)
        {
            var craftedItemId = ItemToModel(recipeDto.ItemProduced);
            var reagents = recipeDto.Reagents.Select(ReagentToModel);

            return new RecipeArtisan
            {
                Id = new ItemIdentifier(recipeDto.Id, recipeDto.Slug),
                Name = recipeDto.Name,
                Cost = recipeDto.Cost,
                Reagents = reagents,
                CraftedItemId = craftedItemId,
                Rank = recipeRank,
                Source = source
            };
        }

        private ItemIdentifier ItemToModel(ArtisanItemTypeDto itemDto)
        {
            return new ItemIdentifier(itemDto.Id, itemDto.Slug);
        }

        private RecipeReagent ReagentToModel(ArtisanReagentDto artisanRecipeDto)
        {
            return new RecipeReagent
            {
                Quantity = artisanRecipeDto.Quantity,
                ItemId = new ItemIdentifier(artisanRecipeDto.Item.Id, artisanRecipeDto.Item.Slug)
            };
        }
    }
}