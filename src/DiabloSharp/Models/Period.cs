using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public abstract class Period : ModelBase<AccountPeriodIdentifier>
    {
        public IDictionary<GameModeIdentifier, long> ParagonLevelsByGameMode { get; internal set; }
    }
}