using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Hero : HeroBase
    {
        public GameModeIdentifier GameMode { get; internal set; }

        public long HighestSoloRift { get; internal set; }

        public IEnumerable<HeroSkillActive> Actives { get; internal set; }

        public IEnumerable<HeroSkillPassive> Passives { get; internal set; }

        public IEnumerable<HeroItemEquipment> Items { get; internal set; }

        public IEnumerable<HeroItemFollower> FollowerItems { get; internal set; }

        public IEnumerable<HeroItemCube> CubeItems { get; internal set; }

        public IEnumerable<HeroStat> Stats { get; internal set; }
    }
}