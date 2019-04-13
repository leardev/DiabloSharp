using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class TimePlayed
    {
        [DataMember(Name = "demon-hunter")]
        public double DemonHunter { get; set; }

        [DataMember(Name = "barbarian")]
        public double Barbarian { get; set; }

        [DataMember(Name = "witch-doctor")]
        public double WitchDoctor { get; set; }

        [DataMember(Name = "necromancer")]
        public double Necromancer { get; set; }

        [DataMember(Name = "wizard")]
        public double Wizard { get; set; }

        [DataMember(Name = "monk")]
        public double Monk { get; set; }

        [DataMember(Name = "crusader")]
        public double Crusader { get; set; }
    }
}