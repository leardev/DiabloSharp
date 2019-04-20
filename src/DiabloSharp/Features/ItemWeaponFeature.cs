namespace DiabloSharp.Features
{
    public class ItemWeaponFeature : IItemFeature
    {
        public string Damage { get; internal set; }

        public string DamageHtml { get; internal set; }

        public string Dps { get; internal set; }

        public bool TwoHanded { get; internal set; }
    }
}