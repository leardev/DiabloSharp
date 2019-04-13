using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraPlayer
    {
        [DataMember(Name = "key")]
        public long Key { get; set; }

        [DataMember(Name = "accountId")]
        public long AccountId { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<EraPlayerData> Datas { get; set; }
    }
}