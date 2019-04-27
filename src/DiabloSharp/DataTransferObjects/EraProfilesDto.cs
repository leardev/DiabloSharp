using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraProfilesDto
    {
        [DataMember(Name = "Era16")]
        public EraProfileDto Era16 { get; set; }

        [DataMember(Name = "Era15")]
        public EraProfileDto Era15 { get; set; }

        [DataMember(Name = "Era14")]
        public EraProfileDto Era14 { get; set; }

        [DataMember(Name = "Era13")]
        public EraProfileDto Era13 { get; set; }

        [DataMember(Name = "Era12")]
        public EraProfileDto Era12 { get; set; }

        [DataMember(Name = "Era0")]
        public EraProfileDto Era0 { get; set; }
    }
}