using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class AccountArtisanDto
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "level")]
        public long Level { get; set; }
    }
}