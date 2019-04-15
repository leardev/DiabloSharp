using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class CharacterSkill
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "tooltipUrl")]
        public string TooltipUrl { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "descriptionHtml")]
        public string DescriptionHtml { get; set; }

        [DataMember(Name = "flavorText")]
        public string FlavorText { get; set; }
    }
}