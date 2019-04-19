using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class EraRowDto
    {
        [DataMember(Name = "player")]
        public IEnumerable<EraPlayerDto> Players { get; set; }

        [DataMember(Name = "order")]
        public long Order { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<EraPlayerDataDto> Datas { get; set; }
    }
}