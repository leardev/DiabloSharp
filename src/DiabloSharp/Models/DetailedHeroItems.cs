using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedHeroItems
    {
        [DataMember(Name = "head")]
        public DetailedHeroItem Head { get; set; }

        [DataMember(Name = "neck")]
        public DetailedHeroItem Neck { get; set; }

        [DataMember(Name = "torso")]
        public DetailedHeroItem Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public DetailedHeroItem Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public DetailedHeroItem Legs { get; set; }

        [DataMember(Name = "waist")]
        public DetailedHeroItem Waist { get; set; }

        [DataMember(Name = "hands")]
        public DetailedHeroItem Hands { get; set; }

        [DataMember(Name = "bracers")]
        public DetailedHeroItem Bracers { get; set; }

        [DataMember(Name = "feet")]
        public DetailedHeroItem Feet { get; set; }

        [DataMember(Name = "leftFinger")]
        public DetailedHeroItem LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public DetailedHeroItem RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public DetailedHeroItem MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public DetailedHeroItem OffHand { get; set; }
    }
}