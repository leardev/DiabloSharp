using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Season
    {
        [DataMember(Name = "_links")]
        public SeasonLinks Links { get; set; }

        [DataMember(Name = "leaderboard")]
        public IEnumerable<SeasonLeaderboard> Leaderboards { get; set; }

        [DataMember(Name = "season_id")]
        public long SeasonId { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }
    }
}