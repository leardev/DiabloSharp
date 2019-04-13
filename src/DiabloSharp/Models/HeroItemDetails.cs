using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroItemDetails
    {
        [DataMember(Name = "head")]
        public HeroItemDetail Head { get; set; }

        [DataMember(Name = "neck")]
        public HeroItemDetail Neck { get; set; }

        [DataMember(Name = "torso")]
        public HeroItemDetail Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public HeroItemDetail Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public HeroItemDetail Legs { get; set; }

        [DataMember(Name = "waist")]
        public HeroItemDetail Waist { get; set; }

        [DataMember(Name = "hands")]
        public HeroItemDetail Hands { get; set; }

        [DataMember(Name = "bracers")]
        public HeroItemDetail Bracers { get; set; }

        [DataMember(Name = "feet")]
        public HeroItemDetail Feet { get; set; }

        [DataMember(Name = "mainHand")]
        public HeroItemDetail MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public HeroItemDetail OffHand { get; set; }
    }
}