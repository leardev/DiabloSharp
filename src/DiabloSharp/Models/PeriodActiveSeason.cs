using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class PeriodActiveSeason : PeriodSeason
    {
        public IEnumerable<ArtisanLevel> ArtisanLevels { get; internal set; }
    }
}