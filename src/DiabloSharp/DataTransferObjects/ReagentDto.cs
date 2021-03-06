using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class ReagentDto
    {
        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "item")]
        public ItemTypeDto Item { get; set; }
    }
}