using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class ItemKindDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "twoHanded")]
        public bool TwoHanded { get; set; }
    }
}