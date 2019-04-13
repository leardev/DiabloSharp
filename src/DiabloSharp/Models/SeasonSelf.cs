using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SeasonSelf
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}