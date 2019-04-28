using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class AccountArtisanLevel : ModelBase
    {
        public ArtisanId ArtisanId { get; internal set; }

        public GameModeId GameMode { get; internal set; }

        public long Level { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(ArtisanId), ArtisanId.ToString());
            builder.AppendProperty(nameof(GameMode), GameMode.ToString());
            builder.AppendProperty(nameof(Level), Level.ToString());
            return builder;
        }
    }
}