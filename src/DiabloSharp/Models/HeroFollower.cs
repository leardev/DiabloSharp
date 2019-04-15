using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollower
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "items")]
        public HeroFollowerItems Items { get; set; }

        [DataMember(Name = "stats")]
        public HeroFollowerStats Stats { get; set; }

        [DataMember(Name = "skills")]
        public IEnumerable<HeroSkill> Skills { get; set; }
    }
}