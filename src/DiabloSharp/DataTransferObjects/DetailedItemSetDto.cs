using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedItemSetDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "descriptionHtml")]
        public string DescriptionHtml { get; set; }
    }
}