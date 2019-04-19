namespace DiabloSharp.Models
{
    public class SkillBase : ModelBase<string>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }

        public Tooltip Tooltip { get; internal set; }
    }
}