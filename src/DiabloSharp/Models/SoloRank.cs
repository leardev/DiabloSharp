using System;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class SoloRank : ModelBase<HeroId>
    {
        public long Rank { get; set; }

        public long Tier { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime Timestamp { get; set; }

        public long Paragon { get; set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Rank), Rank.ToString());
            return builder;
        }
    }
}