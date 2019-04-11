using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ItemTypeIndex
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }
    }
}