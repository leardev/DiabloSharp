using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class ActIndexDto
    {
        [DataMember(Name = "acts")]
        public IEnumerable<ActDto> Acts { get; set; }
    }
}