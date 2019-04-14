using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ActIndex
    {
        [DataMember(Name = "acts")]
        public IEnumerable<Act> Acts { get; set; }
    }
}