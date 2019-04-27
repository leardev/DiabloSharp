using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public abstract class Period : ModelBase<AccountPeriodIdentifier>
    {
        public IEnumerable<PeriodParagon> Paragons { get; internal set; }
    }
}