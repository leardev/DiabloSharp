using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Act
    {
        public Act(ActIdentifier id, string slug, string name, IEnumerable<Quest> quests)
        {
            Id = id;
            Slug = slug;
            Name = name;
            Quests = quests;
        }

        public ActIdentifier Id { get; }

        public string Slug { get; }

        public string Name { get; }

        public IEnumerable<Quest> Quests { get; }
    }
}