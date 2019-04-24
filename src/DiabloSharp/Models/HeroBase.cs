namespace DiabloSharp.Models
{
    public class HeroBase : ModelBase<HeroIdentifier>
    {
        public CharacterClassIdentifier Class { get; internal set; }

        public Gender Gender { get; internal set; }

        public long Level { get; internal set; }

        public GameModeIdentifier GameMode { get; internal set; }
    }
}