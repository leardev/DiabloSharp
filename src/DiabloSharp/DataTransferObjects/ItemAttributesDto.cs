using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class ItemAttributesDto
    {
        [DataMember(Name = "primary")]
        public IEnumerable<ItemHtmlDescriptionDto> Primaries { get; set; }

        [DataMember(Name = "secondary")]
        public IEnumerable<ItemHtmlDescriptionDto> Secondaries { get; set; }

        [DataMember(Name = "other")]
        public IEnumerable<ItemHtmlDescriptionDto> Others { get; set; }
    }
}