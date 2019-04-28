using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public abstract class CharacterSkillBase : ModelBase<CharacterSkillIdentifier>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}