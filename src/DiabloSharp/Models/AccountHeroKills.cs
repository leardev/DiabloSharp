using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountHeroKills
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}