using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SeasonRow
    {
        [DataMember(Name = "player")]
        public IEnumerable<SeasonPlayer> Player { get; set; }

        [DataMember(Name = "order")]
        public long Order { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<SeasonPlayerData> Datas { get; set; }
    }
}