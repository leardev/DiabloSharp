using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class ArtisanDto
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "portrait")]
        public string Portrait { get; set; }

        [DataMember(Name = "training")]
        public ArtisanTrainingDto Training { get; set; }
    }
}