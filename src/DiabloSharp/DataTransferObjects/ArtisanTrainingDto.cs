using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class ArtisanTrainingDto
    {
        [DataMember(Name = "tiers")]
        public IEnumerable<ArtisanTierDto> Tiers { get; set; }
    }
}