using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Artisan
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "portrait")]
        public string Portrait { get; set; }

        [DataMember(Name = "training")]
        public Training Training { get; set; }
    }
}