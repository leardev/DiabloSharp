using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class AccountFallenHero : ModelBase<HeroId>
    {
        public string Name { get; internal set; }

        public CharacterId Character { get; internal set; }

        public HeroGender Gender { get; internal set; }

        public long Level { get; internal set; }

        public bool IsDead { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            builder.AppendProperty(nameof(Character), Character.ToString());
            return builder;
        }
    }
}