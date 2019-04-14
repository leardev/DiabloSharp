using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedHeroItemGem
    {
        [DataMember(Name = "item")]
        public DetailedHeroItemType Item { get; set; }

        [DataMember(Name = "attributes")]
        public IEnumerable<string> Attributes { get; set; }

        [DataMember(Name = "isGem")]
        public bool IsGem { get; set; }

        [DataMember(Name = "isJewel")]
        public bool IsJewel { get; set; }

        [DataMember(Name = "jewelRank")]
        public long? JewelRank { get; set; }

        [DataMember(Name = "jewelSecondaryUnlockRank")]
        public long? JewelSecondaryUnlockRank { get; set; }
    }
}