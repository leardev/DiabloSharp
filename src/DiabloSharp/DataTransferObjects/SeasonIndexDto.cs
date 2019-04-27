using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class SeasonIndexDto
    {
        [DataMember(Name = "_links")]
        public SeasonLinksDto Links { get; set; }

        [DataMember(Name = "season")]
        public IEnumerable<SeasonSelfDto> Seasons { get; set; }

        [DataMember(Name = "current_season")]
        public long CurrentSeason { get; set; }

        [DataMember(Name = "service_current_season")]
        public long ServiceCurrentSeason { get; set; }

        [DataMember(Name = "service_season_state")]
        public string ServiceSeasonState { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }
    }
}