using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class SeasonLinksDto
    {
        [DataMember(Name = "self")]
        public SeasonSelfDto Self { get; set; }
    }
}