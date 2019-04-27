using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroItemsDto
    {
        [DataMember(Name = "head")]
        public HeroItemDto Head { get; set; }

        [DataMember(Name = "neck")]
        public HeroItemDto Neck { get; set; }

        [DataMember(Name = "torso")]
        public HeroItemDto Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public HeroItemDto Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public HeroItemDto Legs { get; set; }

        [DataMember(Name = "waist")]
        public HeroItemDto Waist { get; set; }

        [DataMember(Name = "hands")]
        public HeroItemDto Hands { get; set; }

        [DataMember(Name = "bracers")]
        public HeroItemDto Bracers { get; set; }

        [DataMember(Name = "feet")]
        public HeroItemDto Feet { get; set; }

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