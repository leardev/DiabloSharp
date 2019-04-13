using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollowerStats
    {
        [DataMember(Name = "goldFind")]
        public double GoldFind { get; set; }

        [DataMember(Name = "magicFind")]
        public long MagicFind { get; set; }

        [DataMember(Name = "experienceBonus")]
        public long ExperienceBonus { get; set; }
    }
}