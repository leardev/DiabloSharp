using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Account : ModelBase<BattleTagIdentifier>
    {
        public string Clan { get; internal set; }

        public AccountPeriodEra Era { get; internal set; }

        public AccountPeriodSeason ActiveSeason { get; internal set; }

        public IEnumerable<AccountPeriodSeason> Seasons { get; internal set; }

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