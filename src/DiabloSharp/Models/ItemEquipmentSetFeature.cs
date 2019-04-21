using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class ItemEquipmentSet
    {
        public string Name { get; set; }

        public IEnumerable<ItemIdentifier> ItemIds { get; set; }
    }
}