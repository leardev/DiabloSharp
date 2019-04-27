using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class AccountHeroDto
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "class")]
        public string Class { get; set; }

        [DataMember(Name = "classSlug")]
        public string ClassSlug { get; set; }

        [DataMember(Name = "gender")]
        public long Gender { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "kills")]
        public AccountHeroKillsDto Kills { get; set; }

        [DataMember(Name = "paragonLevel")]
        public long ParagonLevel { get; set; }

        [DataMember(Name = "hardcore")]
        public bool Hardcore { get; set; }

        [DataMember(Name = "seasonal")]
        public bool Seasonal { get; set; }

        [DataMember(Name = "dead")]
        public bool Dead { get; set; }

        [DataMember(Name = "last-updated")]
        public long LastUpdated { get; set; }
    }
}