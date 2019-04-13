using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class AccountArtisan
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }
    }
}