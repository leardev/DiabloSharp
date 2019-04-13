using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraLeaderboardDetail
    {
        [DataMember(Name = "_links")]
        public EraLinks Links { get; set; }

        [DataMember(Name = "row")]
        public IEnumerable<EraRow> Row { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "column")]
        public IEnumerable<EraColumn> Column { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }

        [DataMember(Name = "greater_rift")]
        public bool GreaterRift { get; set; }

        [DataMember(Name = "greater_rift_solo_class")]
        public string GreaterRiftSoloClass { get; set; }

        [DataMember(Name = "achievement_points")]
        public bool AchievementPoints { get; set; }

        [DataMember(Name = "Era")]
        public long Era { get; set; }
    }
}