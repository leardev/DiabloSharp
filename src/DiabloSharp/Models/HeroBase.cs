using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public abstract class HeroBase : ModelBase<HeroIdentifier>
    {
        public string Name { get; internal set; }

        public CharacterIdentifier Class { get; internal set; }

        public Gender Gender { get; internal set; }

        public long Level { get; internal set; }

        public bool IsDead { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            builder.AppendProperty(nameof(Class), Class.ToString());
            return builder;
        }
    }
}