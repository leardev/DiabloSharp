using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class ItemEquipment : Item
    {
        public ItemEquipmentKind Kind { get; internal set; }

        public IEnumerable<ItemEquipmentSlot> Slots { get; internal set; }

        public IEnumerable<CharacterIdentifier> Characters { get; internal set; }

        public bool IsTwoHanded { get; internal set; }

        public ItemEquipmentSet Set { get; internal set; }
    }
}