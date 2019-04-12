using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Acts
    {
        [DataMember(Name = "acts")]
        public IEnumerable<Act> Values { get; set; }
    }
}