using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraLeaderboardDetailDto
    {
        [DataMember(Name = "_links")]
        public EraLinksDto Links { get; set; }

        [DataMember(Name = "row")]
        public IEnumerable<EraRowDto> Rows { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "column")]
        public IEnumerable<EraColumnDto> Columns { get; set; }

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