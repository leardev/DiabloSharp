using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class RecipeReagent : ModelBase
    {
        public long Quantity { get; internal set; }

        public ItemIdentifier ItemId { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(ItemId), ItemId.ToString());
            return builder;
        }
    }
}