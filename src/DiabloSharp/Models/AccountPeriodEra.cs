using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class AccountPeriodEra : AccountPeriod
    {
        public IEnumerable<AccountArtisanLevel> ArtisanLevels { get; internal set; }
    }
}