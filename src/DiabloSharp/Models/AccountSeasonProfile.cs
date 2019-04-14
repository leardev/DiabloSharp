using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountSeasonProfile
    {
        [DataMember(Name = "seasonId")]
        public long Id { get; set; }

        [DataMember(Name = "paragonLevel")]
        public long ParagonLevel { get; set; }

        [DataMember(Name = "paragonLevelHardcore")]
        public long ParagonLevelHardcore { get; set; }

        [DataMember(Name = "kills")]
        public AccountKills Kills { get; set; }

        [DataMember(Name = "timePlayed")]
        public AccountTimePlayed TimePlayed { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public long HighestHardcoreLevel { get; set; }
    }
}