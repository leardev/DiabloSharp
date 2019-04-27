using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraIndexDto
    {
        [DataMember(Name = "_links")]
        public EraLinksDto Links { get; set; }

        [DataMember(Name = "era")]
        public IEnumerable<EraSelfDto> Eras { get; set; }

        [DataMember(Name = "current_era")]
        public long CurrentEra { get; set; }

        [DataMember(Name = "service_current_Era")]
        public long ServiceCurrentEra { get; set; }

        [DataMember(Name = "service_Era_state")]
        public string ServiceEraState { get; set; }

        [DataMember(Name = "last_update_time")]
        public string LastUpdateTime { get; set; }

        [DataMember(Name = "generated_by")]
        public string GeneratedBy { get; set; }
    }
}