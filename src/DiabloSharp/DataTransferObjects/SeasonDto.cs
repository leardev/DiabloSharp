using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class SeasonDto
    {
        [DataMember(Name = "_links")]
        public SeasonLinksDto Links { get; set; }

        [DataMember(Name = "leaderboard")]
        public IEnumerable<SeasonLeaderboardDto> Leaderboards { get; set; }

        [DataMember(Name = "season_id")]
        public long SeasonId { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }
    }
}