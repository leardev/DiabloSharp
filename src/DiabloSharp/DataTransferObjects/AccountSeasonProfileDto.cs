using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class AccountSeasonProfileDto
    {
        [DataMember(Name = "seasonId")]
        public long Id { get; set; }

        [DataMember(Name = "paragonLevel")]
        public long ParagonLevel { get; set; }

        [DataMember(Name = "paragonLevelHardcore")]
        public long ParagonLevelHardcore { get; set; }

        [DataMember(Name = "kills")]
        public AccountKillsDto Kills { get; set; }

        [DataMember(Name = "timePlayed")]
        public AccountTimePlayedDto TimePlayed { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public long HighestHardcoreLevel { get; set; }
    }
}