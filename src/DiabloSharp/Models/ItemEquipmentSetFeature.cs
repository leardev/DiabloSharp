using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class ItemEquipmentSet : ModelBase
    {
        public string Name { get; internal set; }

        public IEnumerable<ItemIdentifier> ItemIds { get; internal set; }
    }
}