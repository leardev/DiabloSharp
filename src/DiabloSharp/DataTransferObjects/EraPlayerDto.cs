using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraPlayerDto
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "accountId")]
        public long AccountId { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<EraPlayerDataDto> Datas { get; set; }
    }
}