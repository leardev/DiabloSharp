using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Attributes
    {
        [DataMember(Name = "primary")]
        public IEnumerable<HtmlDescription> Primaries { get; set; }

        [DataMember(Name = "secondary")]
        public IEnumerable<HtmlDescription> Secondaries { get; set; }

        [DataMember(Name = "other")]
        public IEnumerable<HtmlDescription> Others { get; set; }
    }
}