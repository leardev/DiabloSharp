using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    internal class HeroProgressionDto
    {
        [DataMember(Name = "act1")]
        public HeroActDto Act1 { get; set; }

        [DataMember(Name = "act2")]
        public HeroActDto Act2 { get; set; }

        [DataMember(Name = "act3")]
        public HeroActDto Act3 { get; set; }

        [DataMember(Name = "act4")]
        public HeroActDto Act4 { get; set; }

        [DataMember(Name = "act5")]
        public HeroActDto Act5 { get; set; }
    }
}