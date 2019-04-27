using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraPlayerDataDto
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