using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroFollowerItemsDto
    {
        [DataMember(Name = "neck")]
        public HeroItemDto Neck { get; set; }

        [DataMember(Name = "leftFinger")]
        public HeroItemDto LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public HeroItemDto RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public HeroItemDto MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public HeroItemDto OffHand { get; set; }
    }
}