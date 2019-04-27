namespace DiabloSharp.Models
{
    public class RecipeReagent : ModelBase
    {
        public long Quantity { get; internal set; }

        public ItemIdentifier ItemId { get; internal set; }
    }
}