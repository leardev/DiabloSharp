using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountKills
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }

        [DataMember(Name = "monsters")]
        public long Monsters { get; set; }

        [DataMember(Name = "hardcoreMonsters")]
        public long HardcoreMonsters { get; set; }
    }
}