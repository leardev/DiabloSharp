namespace DiabloSharp.Models
{
    public class Gem : ModelFeatureBase<ItemIdentifier>
    {
        public string Name { get; internal set; }

        public Tooltip Tooltip { get; internal set; }

        public long RequiredLevel { get; internal set; }

        public bool AccountBound { get; internal set; }

        public bool IsSeasonRequiredToDrop { get; internal set; }

        public long SeasonRequiredToDrop { get; internal set; }
        
        public ItemQuality Quality { get; internal set; }
    }
}