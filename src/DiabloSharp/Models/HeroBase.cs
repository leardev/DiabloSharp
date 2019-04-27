namespace DiabloSharp.Models
{
    public abstract class HeroBase : ModelBase<HeroIdentifier>
    {
        public string Name { get; internal set; }

        public CharacterClassIdentifier Class { get; internal set; }

        public Gender Gender { get; internal set; }

        public long Level { get; internal set; }

        public bool IsDead { get; internal set; }
    }
}