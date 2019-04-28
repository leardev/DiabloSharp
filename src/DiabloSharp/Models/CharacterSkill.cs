namespace DiabloSharp.Models
{
    public abstract class CharacterSkill : CharacterSkillBase
    {
        public CharacterSkillType Type { get; internal set; }

        public string TooltipUrl { get; internal set; }

        public string IconUrl { get; internal set; }
    }
}