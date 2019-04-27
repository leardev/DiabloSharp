using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraLinksDto
    {
        [DataMember(Name = "self")]
        public EraSelfDto Self { get; set; }
    }
}