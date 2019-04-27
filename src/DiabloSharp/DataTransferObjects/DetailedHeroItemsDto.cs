using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedHeroItemsDto
    {
        [DataMember(Name = "head")]
        public DetailedHeroItemDto Head { get; set; }

        [DataMember(Name = "neck")]
        public DetailedHeroItemDto Neck { get; set; }

        [DataMember(Name = "torso")]
        public DetailedHeroItemDto Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public DetailedHeroItemDto Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public DetailedHeroItemDto Legs { get; set; }

        [DataMember(Name = "waist")]
        public DetailedHeroItemDto Waist { get; set; }

        [DataMember(Name = "hands")]
        public DetailedHeroItemDto Hands { get; set; }

        [DataMember(Name = "bracers")]
        public DetailedHeroItemDto Bracers { get; set; }

        [DataMember(Name = "feet")]
        public DetailedHeroItemDto Feet { get; set; }

        [DataMember(Name = "leftFinger")]
        public DetailedHeroItemDto LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public DetailedHeroItemDto RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public DetailedHeroItemDto MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public DetailedHeroItemDto OffHand { get; set; }
    }
}