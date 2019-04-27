using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraSelfDto
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}