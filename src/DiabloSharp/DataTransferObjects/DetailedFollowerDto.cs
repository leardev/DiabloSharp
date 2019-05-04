using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedFollowerDto
    {
        [DataMember(Name = "neck")]
        public DetailedItemDto Neck { get; set; }

        [DataMember(Name = "leftFinger")]
        public DetailedItemDto LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public DetailedItemDto RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public DetailedItemDto MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public DetailedItemDto OffHand { get; set; }

        [DataMember(Name = "special")]
        public DetailedItemDto Special { get; set; }
    }
}