using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedHeroItemsDto
    {
        [DataMember(Name = "head")]
        public DetailedItemDto Head { get; set; }

        [DataMember(Name = "neck")]
        public DetailedItemDto Neck { get; set; }

        [DataMember(Name = "torso")]
        public DetailedItemDto Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public DetailedItemDto Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public DetailedItemDto Legs { get; set; }

        [DataMember(Name = "waist")]
        public DetailedItemDto Waist { get; set; }

        [DataMember(Name = "hands")]
        public DetailedItemDto Hands { get; set; }

        [DataMember(Name = "bracers")]
        public DetailedItemDto Bracers { get; set; }

        [DataMember(Name = "feet")]
        public DetailedItemDto Feet { get; set; }

        [DataMember(Name = "leftFinger")]
        public DetailedItemDto LeftFinger { get; set; }

        [DataMember(Name = "rightFinger")]
        public DetailedItemDto RightFinger { get; set; }

        [DataMember(Name = "mainHand")]
        public DetailedItemDto MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public DetailedItemDto OffHand { get; set; }
    }
}