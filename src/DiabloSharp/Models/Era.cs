using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Era
    {
        [DataMember(Name = "_links")]
        public EraLinks Links { get; set; }

        [DataMember(Name = "leaderboard")]
        public IEnumerable<EraLeaderboard> Leaderboards { get; set; }

        [DataMember(Name = "era_id")]
        public long EraId { get; set; }

        [DataMember(Name = "era_start_date")]
        public string EraStartDate { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }
    }
}