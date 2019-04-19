using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class SeasonPlayerDto
    {
        [DataMember(Name = "key")]
        public long Key { get; set; }

        [DataMember(Name = "accountId")]
        public long AccountId { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<SeasonPlayerDataDto> Datas { get; set; }
    }
}