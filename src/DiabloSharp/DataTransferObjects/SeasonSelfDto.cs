using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class SeasonSelfDto
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}