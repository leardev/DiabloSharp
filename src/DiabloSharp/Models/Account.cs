using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class Account : ModelBase<string>
    {
        public string Clan { get; internal set; }

        public HeroIdentifier LastHeroId { get; internal set; }

        public IEnumerable<HeroFallen> FallenHeroes { get; internal set; }

        public IEnumerable<HeroIdentifier> HeroIds { get; internal set; }

        public IDictionary<GameModeIdentifier, long> ParagonLevelsByGameMode { get; internal set; }
    }
}