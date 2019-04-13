using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraPlayerData
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "number")]
        public long? Number { get; set; }

        [DataMember(Name = "timestamp")]
        public long? Timestamp { get; set; }

        [DataMember(Name = "string")]
        public string String { get; set; }
    }
}