using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroItems
    {
        [DataMember(Name = "head")]
        public HeroItem Head { get; set; }

        [DataMember(Name = "neck")]
        public HeroItem Neck { get; set; }

        [DataMember(Name = "torso")]
        public HeroItem Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public HeroItem Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public HeroItem Legs { get; set; }

        [DataMember(Name = "waist")]
        public HeroItem Waist { get; set; }

        [DataMember(Name = "hands")]
        public HeroItem Hands { get; set; }

        [DataMember(Name = "bracers")]
        public HeroItem Bracers { get; set; }

        [DataMember(Name = "feet")]
        public HeroItem Feet { get; set; }

        [DataMember(Name = "mainHand")]
        public HeroItem MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public HeroItem OffHand { get; set; }
    }
}