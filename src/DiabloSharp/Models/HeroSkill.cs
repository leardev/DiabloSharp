using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class HeroSkill : ModelBase<SkillIdentifier>
    {
        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            return builder;
        }
    }
}