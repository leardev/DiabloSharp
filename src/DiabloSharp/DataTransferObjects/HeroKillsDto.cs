using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroKillsDto
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}