using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroPassiveSkillDto
    {
        [DataMember(Name = "skill")]
        public HeroSkillDto Skill { get; set; }
    }
}