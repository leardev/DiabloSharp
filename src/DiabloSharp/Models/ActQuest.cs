using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ActQuest
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }
    }
}