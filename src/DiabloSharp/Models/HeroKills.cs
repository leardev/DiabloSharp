using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroKills
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}