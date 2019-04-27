using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroItemDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "displayColor")]
        public string DisplayColor { get; set; }

        [DataMember(Name = "tooltipParams")]
        public string TooltipParams { get; set; }

        [DataMember(Name = "dyeColor")]
        public HeroItemDyeDto DyeColor { get; set; }

        [DataMember(Name = "transmogItem")]
        public HeroItemTransmogDto TransmogItem { get; set; }
    }
}