using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Hero : ModelBase<HeroIdentifier>
    {
        public string Name { get; internal set; }

        public CharacterIdentifier Character { get; internal set; }

        public HeroGender Gender { get; internal set; }

        public long Level { get; internal set; }

        public bool IsDead { get; internal set; }

        public GameModeIdentifier GameMode { get; internal set; }

        public long HighestSoloRift { get; internal set; }

        public IEnumerable<HeroSkillActive> Actives { get; internal set; }

        public IEnumerable<HeroSkillPassive> Passives { get; internal set; }

        public IEnumerable<HeroItemEquipment> Items { get; internal set; }

        public IEnumerable<HeroItemFollower> FollowerItems { get; internal set; }

        public IEnumerable<HeroItemCube> CubeItems { get; internal set; }

        public IEnumerable<HeroStat> Stats { get; internal set; }

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