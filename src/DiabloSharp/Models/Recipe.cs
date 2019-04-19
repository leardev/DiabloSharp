using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Recipe : ModelBase<ItemIdentifier>
    {
        public Recipe(string id, string slug, string name, long cost, ItemIdentifier craftedItemId, IEnumerable<RecipeReagent> reagents) :
            base(new ItemIdentifier(id, slug))
        {
            Name = name;
            Cost = cost;
            CraftedItemId = craftedItemId;
            Reagents = reagents;
        }

        public string Name { get; }

        public long Cost { get; }

        public IEnumerable<RecipeReagent> Reagents { get; }

        public ItemIdentifier CraftedItemId { get; }
    }
}