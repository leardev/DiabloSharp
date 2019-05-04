using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroItemDto : ItemIdentifierDto
    {
        [DataMember(Name = "displayColor")]
        public string DisplayColor { get; set; }

        [DataMember(Name = "dyeColor")]
        public HeroItemDyeDto DyeColor { get; set; }

        [DataMember(Name = "transmogItem")]
        public HeroItemTransmogDto TransmogItem { get; set; }
    }
}