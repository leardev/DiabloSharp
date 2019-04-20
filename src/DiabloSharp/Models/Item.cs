using System;
using System.Collections.Generic;
using DiabloSharp.Features;

namespace DiabloSharp.Models
{
    public class Item : ModelFeatureBase<ItemIdentifier>
    {
        public string Name { get; internal set; }

        public Tooltip Tooltip { get; internal set; }

        public long RequiredLevel { get; internal set; }

        public ItemKind Kind { get; internal set; }

        public ItemQuality Quality { get; internal set; }

        public IEnumerable<ItemSlot> Slots { get; internal set; }

        public IEnumerable<CharacterClassIdentifier> Classes { get; internal set; }
    }
}