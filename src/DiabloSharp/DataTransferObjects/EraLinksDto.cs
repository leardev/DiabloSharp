using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class EraLinksDto
    {
        [DataMember(Name = "self")]
        public EraSelfDto Self { get; set; }
    }
}