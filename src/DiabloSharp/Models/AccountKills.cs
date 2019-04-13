using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountKills : Kills
    {
        [DataMember(Name = "monsters")]
        public int Monsters { get; set; }

        [DataMember(Name = "hardcoreMonsters")]
        public int HardcoreMonsters { get; set; }
    }
}