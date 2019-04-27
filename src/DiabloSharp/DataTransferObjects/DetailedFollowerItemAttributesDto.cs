using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedFollowerItemAttributesDto
    {
        [DataMember(Name = "primary")]
        public IEnumerable<string> Primaries { get; set; }

        [DataMember(Name = "secondary")]
        public IEnumerable<string> Secondaries { get; set; }
    }
}