using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class SeasonLinksDto
    {
        [DataMember(Name = "self")]
        public SeasonSelfDto Self { get; set; }
    }
}