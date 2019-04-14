using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class CharacterClass
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "maleName")]
        public string MaleName { get; set; }

        [DataMember(Name = "femaleName")]
        public string FemaleName { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "skillCategories")]
        public IEnumerable<CharacterSkillCategory> SkillCategories { get; set; }

        [DataMember(Name = "skills")]
        public CharacterSkills Skills { get; set; }
    }
}