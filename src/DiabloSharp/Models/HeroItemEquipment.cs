namespace DiabloSharp.Models
{
    public class HeroItemEquipment : HeroItem
    {
        public ItemEquipmentSlot Slot { get; internal set; }

        public ItemIdentifier Transmog { get; internal set; }

        public ItemIdentifier Dye { get; internal set; }
    }
}