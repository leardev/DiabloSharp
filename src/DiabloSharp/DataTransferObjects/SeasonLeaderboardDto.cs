using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class SeasonLeaderboardDto
    {
        [DataMember(Name = "ladder")]
        public SeasonSelfDto Ladder { get; set; }

        [DataMember(Name = "team_size")]
        public long? TeamSize { get; set; }

        [DataMember(Name = "hardcore")]
        public bool? Hardcore { get; set; }

        [DataMember(Name = "hero_class_string")]
        public string HeroClassString { get; set; }
    }
}