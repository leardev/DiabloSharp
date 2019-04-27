using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Account : ModelBase<BattleTagIdentifier>
    {
        public string Clan { get; internal set; }

        public PeriodEra Era { get; internal set; }

        public PeriodSeason ActiveSeason { get; internal set; }

        public IEnumerable<PeriodSeason> Seasons { get; internal set; }

        public HeroIdentifier LastHeroId { get; internal set; }

        public IEnumerable<HeroIdentifier> HeroIds { get; internal set; }

        public IEnumerable<HeroFallen> FallenHeros { get; internal set; }
    }
}