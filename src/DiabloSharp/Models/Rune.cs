using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Rune
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "descriptionHtml")]
        public string DescriptionHtml { get; set; }
    }
}