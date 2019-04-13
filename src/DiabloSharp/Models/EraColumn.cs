using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraColumn
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "hidden")]
        public bool Hidden { get; set; }

        [DataMember(Name = "order")]
        public long? Order { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}