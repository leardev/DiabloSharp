using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedFollowerItemRecipeDto
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
        public IEnumerable<DetailedFollowerItemReagentDto> Reagents { get; set; }

        [DataMember(Name = "itemProduced")]
        public DetailedFollowerItemTypeDto ItemProduced { get; set; }
    }
}