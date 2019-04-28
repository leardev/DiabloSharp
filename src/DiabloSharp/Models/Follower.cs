using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Follower : ModelBase<FollowerId>
    {
        public string Name { get; internal set; }

        public string RealName { get; internal set; }

        public string Portrait { get; internal set; }

        public IEnumerable<FollowerSkill> Skills { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}