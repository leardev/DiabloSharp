using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroAct
    {
        [DataMember(Name = "completed")]
        public bool Completed { get; set; }

        [DataMember(Name = "completedQuests")]
        public IEnumerable<object> CompletedQuests { get; set; }
    }
}