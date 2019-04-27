namespace DiabloSharp.Models
{
    public class SkillRune : ModelBase<SkillIdentifier>
    {
        public string Name { get; internal set; }

        public long Level { get; internal set; }
    }
}