using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Reagent
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public ItemType Item { get; set; }
    }
}