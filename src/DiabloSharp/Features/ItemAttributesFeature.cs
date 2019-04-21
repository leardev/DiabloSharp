using System.Collections.Generic;
using DiabloSharp.Models;

namespace DiabloSharp.Features
{
    public class ItemAttributesFeature : IItemFeature
    {
        public IEnumerable<ItemAttribute> Primary { get; internal set; }

        public IEnumerable<ItemAttribute> Secondary { get; internal set; }

        public IEnumerable<ItemAttribute> Other { get; internal set; }
    }
}