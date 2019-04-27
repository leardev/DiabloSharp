using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedFollowerDto
    {
        [DataMember(Name = "neck")]
        public DetailedFollowerItemDto Neck { get; set; }

        [DataMember(Name = "leftFinger")]
        public DetailedFollowerItemDto LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public DetailedFollowerItemDto RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public DetailedFollowerItemDto MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public DetailedFollowerItemDto OffHand { get; set; }

        [DataMember(Name = "special")]
        public DetailedFollowerItemDto Special { get; set; }
    }
}