using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Training
    {
        [DataMember(Name = "tiers")]
        public IEnumerable<Tier> Tiers { get; set; }
    }
}