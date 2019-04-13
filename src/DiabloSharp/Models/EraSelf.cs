using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraSelf
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}