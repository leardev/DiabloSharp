namespace DiabloSharp.Models
{
    public class Item : ModelBase<ItemIdentifier>
    {
        public string Name { get; internal set; }

        public string IconUrl { get; internal set; }

        public string TooltipUrl { get; internal set; }

        public long RequiredLevel { get; internal set; }

        public long StackSize { get; internal set; }

        public bool AccountBound { get; internal set; }

        public ItemCategory Category { get; internal set; }

        public ItemQuality Quality { get; internal set; }
    }
}