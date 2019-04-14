using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountSeasonProfiles
    {
        [DataMember(Name = "season16")]
        public AccountSeasonProfile Season16 { get; set; }

        [DataMember(Name = "season15")]
        public AccountSeasonProfile Season15 { get; set; }

        [DataMember(Name = "season14")]
        public AccountSeasonProfile Season14 { get; set; }

        [DataMember(Name = "season13")]
        public AccountSeasonProfile Season13 { get; set; }

        [DataMember(Name = "season12")]
        public AccountSeasonProfile Season12 { get; set; }

        [DataMember(Name = "season0")]
        public AccountSeasonProfile Season0 { get; set; }
    }
}