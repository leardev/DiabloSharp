using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class DetailedFollowerItemRecipe
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "cost")]
        public long Cost { get; set; }

        [DataMember(Name = "reagents")]
        public IEnumerable<DetailedFollowerItemReagent> Reagents { get; set; }

        [DataMember(Name = "itemProduced")]
        public DetailedFollowerItemType ItemProduced { get; set; }
    }
}