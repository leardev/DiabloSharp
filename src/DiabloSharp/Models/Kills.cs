using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Kills
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}