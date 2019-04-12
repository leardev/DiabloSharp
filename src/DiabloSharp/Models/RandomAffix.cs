using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class RandomAffix
    {
        [DataMember(Name = "oneOf")]
        public IEnumerable<HtmlDescription> OneOfs { get; set; }
    }
}