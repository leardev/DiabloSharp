namespace DiabloSharp.Models
{
    public class HeroItemAttribute : IHeroItemAttribute
    {
        public HeroItemAttributeId Id { get; internal set; }

        public double Value { get; internal set; }

        public override string ToString()
        {
            return $"{nameof(Id)} = {{{Id}}}, {nameof(Value)} = {{{Value}}}";
        }
    }
}