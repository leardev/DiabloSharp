using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedFollowerItemReagentDto
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public DetailedFollowerItemTypeDto Item { get; set; }
    }
}