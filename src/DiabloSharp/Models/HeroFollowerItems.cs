using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollowerItems
    {
        [DataMember(Name = "neck")]
        public HeroItem Neck { get; set; }

        [DataMember(Name = "leftFinger")]
        public HeroItem LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public HeroItem RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public HeroItem MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public HeroItem OffHand { get; set; }
    }
}