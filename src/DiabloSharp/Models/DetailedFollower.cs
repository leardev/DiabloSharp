using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedFollower
    {
        [DataMember(Name = "neck")]
        public DetailedFollowerItem Neck { get; set; }

        [DataMember(Name = "leftFinger")]
        public DetailedFollowerItem LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public DetailedFollowerItem RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public DetailedFollowerItem MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public DetailedFollowerItem OffHand { get; set; }

        [DataMember(Name = "special")]
        public DetailedFollowerItem Special { get; set; }
    }
}