using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class AccountPeriodActiveSeason : AccountPeriodSeason
    {
        public IEnumerable<AccountArtisanLevel> ArtisanLevels { get; internal set; }
    }
}