using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollowerItemDetails
    {
        [DataMember(Name = "neck")]
        public HeroItemDetail Neck { get; set; }

        [DataMember(Name = "leftFinger")]
        public HeroItemDetail LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public HeroItemDetail RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public HeroItemDetail MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public HeroItemDetail OffHand { get; set; }

        [DataMember(Name = "special")]
        public HeroItemDetail Special { get; set; }
    }
}