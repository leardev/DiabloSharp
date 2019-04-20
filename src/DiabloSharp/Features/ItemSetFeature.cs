using System.Collections.Generic;
using DiabloSharp.Models;

namespace DiabloSharp.Features
{
    public class ItemSetFeature : ModelBase<string>, IItemFeature
    {
        public string NameHtml { get; internal set; }

        public Tooltip Tooltip { get; internal set; }

        public IEnumerable<ItemIdentifier> ItemIds { get; internal set; }
    }
}