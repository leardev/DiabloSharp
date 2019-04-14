using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedHeroItemKind
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "twoHanded")]
        public bool TwoHanded { get; set; }
    }
}