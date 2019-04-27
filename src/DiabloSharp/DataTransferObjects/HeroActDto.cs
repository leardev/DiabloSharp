using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroActDto
    {
        [DataMember(Name = "completed")]
        public bool Completed { get; set; }

        [DataMember(Name = "completedQuests")]
        public IEnumerable<HeroCompletedQuestDto> CompletedQuests { get; set; }
    }
}