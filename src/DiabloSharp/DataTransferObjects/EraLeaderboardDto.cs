using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class EraLeaderboardDto
    {
        [DataMember(Name = "ladder")]
        public EraSelfDto Ladder { get; set; }

        [DataMember(Name = "team_size")]
        public long? TeamSize { get; set; }

        [DataMember(Name = "hardcore")]
        public bool? Hardcore { get; set; }

        [DataMember(Name = "hero_class_string")]
        public string HeroClassString { get; set; }
    }
}