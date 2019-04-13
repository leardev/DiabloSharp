using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    public class EraProfile
    {
        [DataContract]
        public class ProfileSeason
        {
            [DataMember(Name = "eraId")]
            public int Id { get; set; }

            [DataMember(Name = "paragonLevel")]
            public int ParagonLevel { get; set; }

            [DataMember(Name = "paragonLevelHardcore")]
            public int ParagonLevelHardcore { get; set; }

            [DataMember(Name = "kills")]
            public AccountKills Kills { get; set; }

            [DataMember(Name = "timePlayed")]
            public TimePlayed TimePlayed { get; set; }

            [DataMember(Name = "highestHardcoreLevel")]
            public int HighestHardcoreLevel { get; set; }
        }
    }
}