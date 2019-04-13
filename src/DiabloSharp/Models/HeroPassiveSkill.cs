using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroPassiveSkill
    {
        [DataMember(Name = "skill")]
        public Skill Skill { get; set; }
    }
}