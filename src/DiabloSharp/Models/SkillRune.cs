namespace DiabloSharp.Models
{
    public class SkillRune : ModelBase<string>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }

        public Tooltip Tooltip { get; internal set; }
    }
}