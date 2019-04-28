namespace DiabloSharp.Models
{
    public class HeroItemEquipment : HeroItem
    {
        public ItemEquipmentSlot Slot { get; internal set; }

        public ItemId Transmog { get; internal set; }

        public ItemId Dye { get; internal set; }
    }
}