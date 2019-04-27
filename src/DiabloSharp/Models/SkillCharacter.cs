namespace DiabloSharp.Models
{
    public class SkillCharacter : SkillBase<SkillIdentifier>
    {
        public SkillCategory Category { get; internal set; }
    }
}