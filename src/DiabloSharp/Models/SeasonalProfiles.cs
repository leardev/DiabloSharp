using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class SeasonalProfiles
    {
        [DataMember(Name = "season16")]
        public Season Season16 { get; set; }

        [DataMember(Name = "season15")]
        public Season Season15 { get; set; }

        [DataMember(Name = "season14")]
        public Season Season14 { get; set; }

        [DataMember(Name = "season13")]
        public Season Season13 { get; set; }

        [DataMember(Name = "season12")]
        public Season Season12 { get; set; }

        [DataMember(Name = "season0")]
        public Season Season0 { get; set; }
    }
}