using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SeasonLinks
    {
        [DataMember(Name = "self")]
        public SeasonSelf Self { get; set; }
    }
}