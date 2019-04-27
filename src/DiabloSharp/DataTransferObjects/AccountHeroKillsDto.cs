using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class AccountHeroKillsDto
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}