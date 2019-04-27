using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Recipe : ModelBase<ItemIdentifier>
    {
        public string Name { get; internal set; }

        public long Cost { get; internal set; }

        public IEnumerable<RecipeReagent> Reagents { get; internal set; }

        public ItemIdentifier CraftedItemId { get; internal set; }
    }
}