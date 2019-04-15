using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountFallenHero
    {
        [DataMember(Name = "heroId")]
        public long HeroId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "class")]
        public string Class { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }

        [DataMember(Name = "elites")]
        public long Elites { get; set; }

        [DataMember(Name = "hardcore")]
        public bool Hardcore { get; set; }

        [DataMember(Name = "death")]
        public AccountDeath Death { get; set; }

        [DataMember(Name = "gender")]
        public long Gender { get; set; }
    }
}