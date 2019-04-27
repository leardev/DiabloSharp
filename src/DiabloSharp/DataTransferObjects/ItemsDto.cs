using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class ItemsDto
    {
        [DataMember(Name = "head")]
        public ItemDto Head { get; set; }

        [DataMember(Name = "neck")]
        public ItemDto Neck { get; set; }

        [DataMember(Name = "torso")]
        public ItemDto Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public ItemDto Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public ItemDto Legs { get; set; }

        [DataMember(Name = "waist")]
        public ItemDto Waist { get; set; }

        [DataMember(Name = "hands")]
        public ItemDto Hands { get; set; }

        [DataMember(Name = "bracers")]
        public ItemDto Bracers { get; set; }

        [DataMember(Name = "feet")]
        public ItemDto Feet { get; set; }

        [DataMember(Name = "mainHand")]
        public ItemDto MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public ItemDto OffHand { get; set; }
    }
}