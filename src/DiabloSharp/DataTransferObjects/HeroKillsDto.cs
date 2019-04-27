using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroKillsDto
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}