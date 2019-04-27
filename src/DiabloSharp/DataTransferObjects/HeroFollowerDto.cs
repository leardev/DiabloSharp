using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroFollowerDto
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "items")]
        public HeroFollowerItemsDto Items { get; set; }

        [DataMember(Name = "stats")]
        public HeroFollowerStatsDto Stats { get; set; }

        [DataMember(Name = "skills")]
        public IEnumerable<HeroSkillDto> Skills { get; set; }
    }
}