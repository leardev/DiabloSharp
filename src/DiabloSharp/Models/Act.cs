﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Act
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "quests")]
        public IEnumerable<Quest> Quests { get; set; }
    }
}