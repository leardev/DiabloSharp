using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroDto
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "class")]
        public string Class { get; set; }

        [DataMember(Name = "gender")]
        public long Gender { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "paragonLevel")]
        public long ParagonLevel { get; set; }

        [DataMember(Name = "kills")]
        public HeroKillsDto Kills { get; set; }

        [DataMember(Name = "hardcore")]
        public bool Hardcore { get; set; }

        [DataMember(Name = "seasonal")]
        public bool Seasonal { get; set; }

        [DataMember(Name = "seasonCreated")]
        public long SeasonCreated { get; set; }

        [DataMember(Name = "skills")]
        public HeroSkillsDto Skills { get; set; }

        [DataMember(Name = "items")]
        public HeroItemsDto Items { get; set; }

        [DataMember(Name = "followers")]
        public HeroFollowersDto Followers { get; set; }

        [DataMember(Name = "legendaryPowers")]
        public IEnumerable<HeroItemDto> LegendaryPowers { get; set; }

        [DataMember(Name = "progression")]
        public HeroProgressionDto Progression { get; set; }

        [DataMember(Name = "alive")]
        public bool Alive { get; set; }

        [DataMember(Name = "lastUpdated")]
        public long LastUpdated { get; set; }

        [DataMember(Name = "highestSoloRiftCompleted")]
        public long HighestSoloRiftCompleted { get; set; }

        [DataMember(Name = "stats")]
        public Dictionary<string, double> Stats { get; set; }
    }
}