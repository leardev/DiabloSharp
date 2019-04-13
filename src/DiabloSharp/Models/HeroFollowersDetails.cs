using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollowersDetails
    {
        [DataMember(Name = "templar")]
        public HeroFollowerItemDetails Templar { get; set; }

        [DataMember(Name = "scoundrel")]
        public HeroFollowerItemDetails Scoundrel { get; set; }

        [DataMember(Name = "enchantress")]
        public HeroFollowerItemDetails Enchantress { get; set; }
    }
}