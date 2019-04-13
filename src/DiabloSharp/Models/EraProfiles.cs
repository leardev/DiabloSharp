using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class EraProfiles
    {
        [DataMember(Name = "Era16")]
        public EraProfile Era16 { get; set; }

        [DataMember(Name = "Era15")]
        public EraProfile Era15 { get; set; }

        [DataMember(Name = "Era14")]
        public EraProfile Era14 { get; set; }

        [DataMember(Name = "Era13")]
        public EraProfile Era13 { get; set; }

        [DataMember(Name = "Era12")]
        public EraProfile Era12 { get; set; }

        [DataMember(Name = "Era0")]
        public EraProfile Era0 { get; set; }
    }
}