using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedFollowerItemKindDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "twoHanded")]
        public bool TwoHanded { get; set; }
    }
}