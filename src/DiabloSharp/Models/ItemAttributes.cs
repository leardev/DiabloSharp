using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ItemAttributes
    {
        [DataMember(Name = "primary")]
        public IEnumerable<ItemHtmlDescription> Primaries { get; set; }

        [DataMember(Name = "secondary")]
        public IEnumerable<ItemHtmlDescription> Secondaries { get; set; }

        [DataMember(Name = "other")]
        public IEnumerable<ItemHtmlDescription> Others { get; set; }
    }
}