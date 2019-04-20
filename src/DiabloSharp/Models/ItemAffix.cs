using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class ItemAffix
    {
        public IEnumerable<ItemAttribute> OneOf { get; internal set; }
    }
}