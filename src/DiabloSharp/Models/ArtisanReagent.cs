using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ArtisanReagent
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public ArtisanItemType Item { get; set; }
    }
}