using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroFollowers
    {
        [DataMember(Name = "templar")]
        public HeroFollower Templar { get; set; }

        [DataMember(Name = "scoundrel")]
        public HeroFollower Scoundrel { get; set; }

        [DataMember(Name = "enchantress")]
        public HeroFollower Enchantress { get; set; }
    }
}