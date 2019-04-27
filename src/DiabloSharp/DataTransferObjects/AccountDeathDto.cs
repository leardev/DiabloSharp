using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class AccountDeathDto
    {
        [DataMember(Name = "killer")]
        public long Killer { get; set; }

        [DataMember(Name = "time")]
        public long Time { get; set; }
    }
}