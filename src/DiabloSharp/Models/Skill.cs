using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Skill : ModelBase<string>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }

        public SkillCategory Category { get; internal set; }

        public Tooltip Tooltip { get; internal set; }

        public IEnumerable<SkillRune> Runes { get; internal set; }
    }
}