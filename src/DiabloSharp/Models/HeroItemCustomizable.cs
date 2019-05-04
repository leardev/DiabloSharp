using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class HeroItemCustomizable : HeroItem
    {
        public ItemId Transmog { get; internal set; }

        public ItemId Dye { get; internal set; }

        public IEnumerable<HeroItemGem> Gems { get; internal set; }
    }
}