using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class DetailedFollowersDto
    {
        [DataMember(Name = "templar")]
        public DetailedFollowerDto Templar { get; set; }

        [DataMember(Name = "scoundrel")]
        public DetailedFollowerDto Scoundrel { get; set; }

        [DataMember(Name = "enchantress")]
        public DetailedFollowerDto Enchantress { get; set; }
    }
}