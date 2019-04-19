namespace DiabloSharp.Models
{
    public class RecipeReagent
    {
        public RecipeReagent(ItemIdentifier itemId, long quantity)
        {
            Quantity = quantity;
            ItemId = itemId;
        }

        public long Quantity { get; }

        public ItemIdentifier ItemId { get; }
    }
}