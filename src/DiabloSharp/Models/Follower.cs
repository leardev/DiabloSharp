using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Follower : ModelBase<string>
    {
        public string Name { get; internal set; }

        public string RealName { get; internal set; }

        public string Portrait { get; internal set; }

        public IEnumerable<SkillFollower> Skills { get; internal set; }
    }
}