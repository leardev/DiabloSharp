using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class PeriodEra : Period
    {
        public IEnumerable<ArtisanLevel> ArtisanLevels { get; internal set; }
    }
}