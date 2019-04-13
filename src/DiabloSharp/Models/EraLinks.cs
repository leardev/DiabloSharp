using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraLinks
    {
        [DataMember(Name = "self")]
        public EraSelf Self { get; set; }
    }
}