namespace DiabloSharp.Models
{
    public class HeroStat : ModelBase<HeroStatIdentifier>
    {
        public double Value { get; internal set; }
    }
}