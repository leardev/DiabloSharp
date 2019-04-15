using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountDeath
    {
        [DataMember(Name = "killer")]
        public long Killer { get; set; }

        [DataMember(Name = "time")]
        public long Time { get; set; }
    }
}