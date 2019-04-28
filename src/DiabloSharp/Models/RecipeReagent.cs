using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class RecipeReagent : ModelBase<ItemIdentifier>
    {
        public long Quantity { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            return builder;
        }
    }
}