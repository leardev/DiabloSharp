namespace DiabloSharp.Models
{
    public class SkillCharacter : SkillBase<SkillCharacterIdentifier>
    {
        public SkillCategory Category { get; internal set; }
    }
}