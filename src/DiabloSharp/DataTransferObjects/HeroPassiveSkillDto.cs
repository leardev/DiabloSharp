using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroPassiveSkillDto
    {
        [DataMember(Name = "skill")]
        public HeroSkillDto Skill { get; set; }
    }
}