using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollowerStats
    {
        [DataMember(Name = "goldFind")]
        public double GoldFind { get; set; }

        [DataMember(Name = "magicFind")]
        public double MagicFind { get; set; }

        [DataMember(Name = "experienceBonus")]
        public double ExperienceBonus { get; set; }
    }
}