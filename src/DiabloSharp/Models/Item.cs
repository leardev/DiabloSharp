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

        /*
         * has not use
         * public string TypeName { get; internal set; }
         *
         * deprecated since S4, always false
         * public bool IsSeasonRequiredToDrop { get; internal set; }
         *
         * deprecated since S4, used by some items (values: 1-4)
         * public bool SeasonRequiredToDrop { get; internal set; }
        */
    }
}