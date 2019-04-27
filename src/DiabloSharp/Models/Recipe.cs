using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Recipe : ModelBase<ItemIdentifier>
    {
        public string Name { get; internal set; }

        public long Cost { get; internal set; }

        public IEnumerable<RecipeReagent> Reagents { get; internal set; }

        public ItemIdentifier CraftedItemId { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}