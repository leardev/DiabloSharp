using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SkillCategory
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}