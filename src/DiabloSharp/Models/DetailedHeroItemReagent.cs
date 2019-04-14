using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedHeroItemReagent
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public DetailedHeroItemType Item { get; set; }
    }
}