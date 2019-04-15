using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ArtisanTraining
    {
        [DataMember(Name = "tiers")]
        public IEnumerable<ArtisanTier> Tiers { get; set; }
    }
}