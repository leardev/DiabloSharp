using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraRow
    {
        [DataMember(Name = "player")]
        public IEnumerable<EraPlayer> Players { get; set; }

        [DataMember(Name = "order")]
        public long Order { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<EraPlayerData> Datas { get; set; }
    }
}