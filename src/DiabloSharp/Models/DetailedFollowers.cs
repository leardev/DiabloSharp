using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedFollowers
    {
        [DataMember(Name = "templar")]
        public DetailedFollower Templar { get; set; }

        [DataMember(Name = "scoundrel")]
        public DetailedFollower Scoundrel { get; set; }

        [DataMember(Name = "enchantress")]
        public DetailedFollower Enchantress { get; set; }
    }
}