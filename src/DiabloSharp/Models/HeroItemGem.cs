namespace DiabloSharp.Models
{
    public class HeroItemGem : HeroItem
    {
        public bool IsLegendary { get; set; }

        public long Rank { get; internal set; }
    }
}