using System.Globalization;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class HeroStat : ModelBase<HeroStatId>
    {
        public double Value { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Value), Value.ToString(CultureInfo.CurrentCulture));
            return builder;
        }
    }
}