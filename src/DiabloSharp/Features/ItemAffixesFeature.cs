using System.Collections.Generic;
using DiabloSharp.Models;

namespace DiabloSharp.Features
{
    public class ItemAffixesFeature : IItemFeature
    {
        public IEnumerable<ItemAffix> Affixes { get; internal set; }
    }
}