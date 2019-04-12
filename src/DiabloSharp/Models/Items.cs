using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Items
    {
        [DataMember(Name = "head")]
        public Item Head { get; set; }

        [DataMember(Name = "neck")]
        public Item Neck { get; set; }

        [DataMember(Name = "torso")]
        public Item Torso { get; set; }

        [DataMember(Name = "shoulders")]
        public Item Shoulders { get; set; }

        [DataMember(Name = "legs")]
        public Item Legs { get; set; }

        [DataMember(Name = "waist")]
        public Item Waist { get; set; }

        [DataMember(Name = "hands")]
        public Item Hands { get; set; }

        [DataMember(Name = "bracers")]
        public Item Bracers { get; set; }

        [DataMember(Name = "feet")]
        public Item Feet { get; set; }

        [DataMember(Name = "mainHand")]
        public Item MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public Item OffHand { get; set; }
    }
}