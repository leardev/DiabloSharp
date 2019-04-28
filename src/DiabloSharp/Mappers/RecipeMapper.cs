using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class RecipeMapper : Mapper<RecipeDto, Recipe>
    {
        private readonly ArtisanIdentifier _artisanId;

        public RecipeMapper(ArtisanIdentifier artisanId)
        {
            _artisanId = artisanId;
        }

        protected override void Map(RecipeDto input, Recipe output)
        {
            var reagents = MapReagents(input.Reagents);

            output.Id = new RecipeIdentifier(_artisanId, input.Slug);
            output.Name = input.Name;
            output.Cost = input.Cost;
            output.Reagents = reagents;
            output.CraftedItemId = new ItemIdentifier(input.ItemProduced.Slug, input.ItemProduced.Id);
        }

        private IEnumerable<RecipeReagent> MapReagents(IEnumerable<ReagentDto> inputs)
        {
            var outputs = new List<RecipeReagent>();
            foreach (var input in inputs)
            {
                var output = MapReagent(input);
                outputs.Add(output);
            }

            return outputs;
        }

        private RecipeReagent MapReagent(ReagentDto input)
        {
            return new RecipeReagent
            {
                Quantity = input.Quantity,
                Id = new ItemIdentifier(input.Item.Slug, input.Item.Id)
            };
        }
    }
}