using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class FollowerDto
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "realName")]
        public string RealName { get; set; }

        [DataMember(Name = "portrait")]
        public string Portrait { get; set; }

        [DataMember(Name = "skills")]
        public IEnumerable<FollowerSkillDto> Skills { get; set; }
    }
}