namespace DiabloSharp.Features
{
    public class ItemArmorFeature : IItemFeature
    {
        public string Armor { get; internal set; }

        public string ArmorHtml { get; internal set; }

        public string Block { get; internal set; }

        public string BlockHtml { get; internal set; }
    }
}