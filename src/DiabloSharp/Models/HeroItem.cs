using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroItem
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
        public HeroItemDye DyeColor { get; set; }

        [DataMember(Name = "transmogItem")]
        public HeroItemTransmog TransmogItem { get; set; }
    }
}