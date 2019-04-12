using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Death
    {
        [DataMember(Name = "killer")]
        public int Killer { get; set; }

        [DataMember(Name = "time")]
        public int Time { get; set; }
    }
}