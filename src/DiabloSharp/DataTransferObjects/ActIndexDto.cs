using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class ActIndexDto
    {
        [DataMember(Name = "acts")]
        public IEnumerable<ActDto> Acts { get; set; }
    }
}