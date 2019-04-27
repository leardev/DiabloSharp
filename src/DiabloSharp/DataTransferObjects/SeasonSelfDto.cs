using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class SeasonSelfDto
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}