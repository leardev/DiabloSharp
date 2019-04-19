using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class AccountDeathDto
    {
        [DataMember(Name = "killer")]
        public long Killer { get; set; }

        [DataMember(Name = "time")]
        public long Time { get; set; }
    }
}