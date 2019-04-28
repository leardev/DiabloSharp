using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Item : ModelBase<ItemId>
    {
        public string Name { get; internal set; }

        public string IconUrl { get; internal set; }

        public string TooltipUrl { get; internal set; }

        public long RequiredLevel { get; internal set; }

        public long StackSize { get; internal set; }

        public bool AccountBound { get; internal set; }

        public ItemCategory Category { get; internal set; }

        public ItemQuality Quality { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(Name, Name);
            return builder;
        }
    }
}