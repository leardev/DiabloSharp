using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class FallenHero
    {
        [DataMember(Name = "heroId")]
        public int HeroId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "class")]
        public string Class { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "elites")]
        public int Elites { get; set; }

        [DataMember(Name = "hardcore")]
        public bool Hardcore { get; set; }

        [DataMember(Name = "death")]
        public Death Death { get; set; }

        [DataMember(Name = "gender")]
        public int Gender { get; set; }
    }
}