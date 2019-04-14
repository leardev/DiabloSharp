using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedFollowerItemReagent
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public DetailedFollowerItemType Item { get; set; }
    }
}