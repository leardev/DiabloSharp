using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class ItemRandomAffixDto
    {
        [DataMember(Name = "oneOf")]
        public IEnumerable<ItemHtmlDescriptionDto> OneOfs { get; set; }
    }
}