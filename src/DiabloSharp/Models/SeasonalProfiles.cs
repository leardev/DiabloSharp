using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SeasonalProfiles
    {
        [DataMember(Name = "season16")]
        public ProfileSeason Season16 { get; set; }

        [DataMember(Name = "season15")]
        public ProfileSeason Season15 { get; set; }

        [DataMember(Name = "season14")]
        public ProfileSeason Season14 { get; set; }

        [DataMember(Name = "season13")]
        public ProfileSeason Season13 { get; set; }

        [DataMember(Name = "season12")]
        public ProfileSeason Season12 { get; set; }

        [DataMember(Name = "season0")]
        public ProfileSeason Season0 { get; set; }
    }
}