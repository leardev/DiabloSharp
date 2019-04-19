using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class EraSelfDto
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}