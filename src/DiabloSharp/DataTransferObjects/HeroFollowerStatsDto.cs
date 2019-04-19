using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroFollowerStatsDto
    {
        [DataMember(Name = "goldFind")]
        public double GoldFind { get; set; }

        [DataMember(Name = "magicFind")]
        public double MagicFind { get; set; }

        [DataMember(Name = "experienceBonus")]
        public double ExperienceBonus { get; set; }
    }
}