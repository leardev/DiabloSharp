using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    public class HeroProgression
    {
        [DataMember(Name = "act1")]
        public HeroAct Act1 { get; set; }

        [DataMember(Name = "act2")]
        public HeroAct Act2 { get; set; }

        [DataMember(Name = "act3")]
        public HeroAct Act3 { get; set; }

        [DataMember(Name = "act4")]
        public HeroAct Act4 { get; set; }

        [DataMember(Name = "act5")]
        public HeroAct Act5 { get; set; }
    }
}