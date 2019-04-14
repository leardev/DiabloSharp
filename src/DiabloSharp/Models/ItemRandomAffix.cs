using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ItemRandomAffix
    {
        [DataMember(Name = "oneOf")]
        public IEnumerable<ItemHtmlDescription> OneOfs { get; set; }
    }
}