namespace DiabloSharp.Models
{
    public class Item : ModelBase<ItemIdentifier>
    {
        public string Name { get; set; }

        public string IconUrl { get; set; }

        public string TooltipUrl { get; set; }

        public long RequiredLevel { get; set; }

        public long StackSize { get; set; }

        public bool AccountBound { get; set; }

        public ItemCategory Category { get; set; }

        public ItemQuality Quality { get; set; }

        /*
         * has not use
         * public string TypeName { get; set; }
         *
         * deprecated since S4, always false
         * public bool IsSeasonRequiredToDrop { get; set; }
         *
         * deprecated since S4, used by some items (values: 1-4)
         * public bool SeasonRequiredToDrop { get; set; }
        */
    }
}