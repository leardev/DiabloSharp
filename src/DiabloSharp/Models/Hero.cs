using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Hero
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
        public HeroKills Kills { get; set; }

        [DataMember(Name = "hardcore")]
        public bool Hardcore { get; set; }

        [DataMember(Name = "seasonal")]
        public bool Seasonal { get; set; }

        [DataMember(Name = "seasonCreated")]
        public long SeasonCreated { get; set; }

        [DataMember(Name = "skills")]
        public HeroSkills Skills { get; set; }

        [DataMember(Name = "items")]
        public HeroItems Items { get; set; }

        [DataMember(Name = "followers")]
        public HeroFollowers Followers { get; set; }

        [DataMember(Name = "legendaryPowers")]
        public IEnumerable<HeroItem> LegendaryPowers { get; set; }

        [DataMember(Name = "progression")]
        public HeroProgression Progression { get; set; }

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