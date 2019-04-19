using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class AccountHeroKillsDto
    {
        [DataMember(Name = "elites")]
        public long Elites { get; set; }
    }
}