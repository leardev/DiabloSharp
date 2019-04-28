namespace DiabloSharp.Models
{
    public abstract class CharacterSkill : CharacterSkillBase
    {
        public CharacterSkillKind Kind { get; internal set; }

        public string TooltipUrl { get; internal set; }

        public string IconUrl { get; internal set; }
    }
}