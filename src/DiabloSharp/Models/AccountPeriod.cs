using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public abstract class AccountPeriod : ModelBase<AccountPeriodId>
    {
        public IEnumerable<AccountPeriodParagon> Paragons { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            return builder;
        }
    }
}