namespace DiabloSharp.Models
{
    internal class HeroItemAttributeWeaponDamage : IHeroItemAttribute
    {
        public double Minimum { get; internal set; }

        public double Maximum { get; internal set; }

        public double AttacksPerSecond { get; internal set; }

        public double Dps { get; internal set; }
    }
}