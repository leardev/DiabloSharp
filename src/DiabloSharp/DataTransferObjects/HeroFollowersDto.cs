using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class HeroFollowersDto
    {
        [DataMember(Name = "templar")]
        public HeroFollowerDto Templar { get; set; }

        [DataMember(Name = "scoundrel")]
        public HeroFollowerDto Scoundrel { get; set; }

        [DataMember(Name = "enchantress")]
        public HeroFollowerDto Enchantress { get; set; }
    }
}