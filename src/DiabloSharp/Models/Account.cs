using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Account : ModelBase<BattleTagIdentifier>
    {
        public string Clan { get; internal set; }

        public PeriodEra Era { get; internal set; }

        public PeriodSeason ActiveSeason { get; internal set; }

        public IEnumerable<PeriodSeason> Seasons { get; internal set; }

        public IEnumerable<HeroIdentifier> HeroIds { get; internal set; }

        public IEnumerable<AccountFallenHero> FallenHeros { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            return builder;
        }
    }
}