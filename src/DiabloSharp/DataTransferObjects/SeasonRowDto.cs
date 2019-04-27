using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class SeasonRowDto
    {
        [DataMember(Name = "player")]
        public IEnumerable<SeasonPlayerDto> Players { get; set; }

        [DataMember(Name = "order")]
        public long Order { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<SeasonPlayerDataDto> Datas { get; set; }
    }
}