using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedItemReagentDto
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public DetailedItemTypeDto Item { get; set; }
    }
}