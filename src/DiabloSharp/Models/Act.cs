using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Act : ModelBase<ActIdentifier>
    {
        public Act(ActIdentifier id, string slug, string name, IEnumerable<Quest> quests) : base(id)
        {
            Slug = slug;
            Name = name;
            Quests = quests;
        }

        public string Slug { get; }

        public string Name { get; }

        public IEnumerable<Quest> Quests { get; }
    }
}