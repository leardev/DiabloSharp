using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class FollowerSkill : ModelBase<FollowerSkillId>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }

        public string TooltipUrl { get; internal set; }

        public string IconUrl { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}