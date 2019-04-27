namespace DiabloSharp.Models
{
    public class ArtisanLevel : ModelBase
    {
        public ArtisanIdentifier Artisan { get; internal set; }

        public GameModeIdentifier GameMode { get; internal set; }

        public long Level { get; internal set; }
    }
}