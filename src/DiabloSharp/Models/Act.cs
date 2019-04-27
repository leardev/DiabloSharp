using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Act : ModelBase<ActIdentifier>
    {
        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public IEnumerable<Quest> Quests { get; internal set; }
    }
}