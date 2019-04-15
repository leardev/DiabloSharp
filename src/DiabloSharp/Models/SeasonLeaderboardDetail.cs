using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SeasonLeaderboardDetail
    {
        [DataMember(Name = "_links")]
        public SeasonLinks Links { get; set; }

        [DataMember(Name = "row")]
        public IEnumerable<SeasonRow> Rows { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "column")]
        public IEnumerable<SeasonColumn> Columns { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }

        [DataMember(Name = "achievement_points")]
        public bool AchievementPoints { get; set; }

        [DataMember(Name = "season")]
        public long Season { get; set; }
    }
}