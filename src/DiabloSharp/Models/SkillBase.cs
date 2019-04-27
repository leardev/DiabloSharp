namespace DiabloSharp.Models
{
    public class SkillBase<T> : ModelBase<T>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }

        public string TooltipUrl { get; internal set; }

        public string IconUrl { get; internal set; }
    }
}