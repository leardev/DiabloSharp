using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroActiveSkillDto
    {
        [DataMember(Name = "skill")]
        public HeroSkillDto Skill { get; set; }

        [DataMember(Name = "rune")]
        public HeroRuneDto Rune { get; set; }
    }
}