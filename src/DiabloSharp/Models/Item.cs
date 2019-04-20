using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Item : ModelFeatureBase<ItemIdentifier>
    {
        public string Name { get; internal set; }

        public Tooltip Tooltip { get; internal set; }

        public long RequiredLevel { get; internal set; }

        public bool AccountBound { get; internal set; }

        public bool IsSeasonRequiredToDrop { get; internal set; }

        public long SeasonRequiredToDrop { get; internal set; }

        public ItemKind Kind { get; internal set; }

        public ItemQuality Quality { get; internal set; }

        public IEnumerable<ItemSlot> Slots { get; internal set; }

        public IEnumerable<CharacterClassIdentifier> Classes { get; internal set; }
    }
}