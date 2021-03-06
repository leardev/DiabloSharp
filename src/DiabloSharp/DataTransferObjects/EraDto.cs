using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DiabloSharp.Formatters;
using Utf8Json;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraDto
    {
        [DataMember(Name = "_links")]
        public EraLinksDto Links { get; set; }

        [DataMember(Name = "leaderboard")]
        public IEnumerable<EraLeaderboardDto> Leaderboards { get; set; }

        [DataMember(Name = "era_id")]
        public long EraId { get; set; }

        [DataMember(Name = "era_start_date")]
        [JsonFormatter(typeof(UnixTimestampLongDateTimeFormatter))]
        public DateTime EraStartDate { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }
    }
}