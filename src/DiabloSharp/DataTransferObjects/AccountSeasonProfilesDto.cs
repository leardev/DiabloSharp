using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class AccountSeasonProfilesDto
    {
        [DataMember(Name = "season16")]
        public AccountSeasonProfileDto Season16 { get; set; }

        [DataMember(Name = "season15")]
        public AccountSeasonProfileDto Season15 { get; set; }

        [DataMember(Name = "season14")]
        public AccountSeasonProfileDto Season14 { get; set; }

        [DataMember(Name = "season13")]
        public AccountSeasonProfileDto Season13 { get; set; }

        [DataMember(Name = "season12")]
        public AccountSeasonProfileDto Season12 { get; set; }

        [DataMember(Name = "season0")]
        public AccountSeasonProfileDto Season0 { get; set; }
    }
}