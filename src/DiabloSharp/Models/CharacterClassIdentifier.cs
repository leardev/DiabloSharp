using DiabloSharp.Attributes;

namespace DiabloSharp.Models
{
    public enum CharacterClassIdentifier
    {
        [LocalizationEnUs("Barbarian")]
        Barbarian,
        [LocalizationEnUs("Crusader")]
        Crusader,
        [LocalizationEnUs("Demon Hunter")]
        DemonHunter,
        [LocalizationEnUs("Monk")]
        Monk,
        [LocalizationEnUs("Necromancer")]
        Necromancer,
        [LocalizationEnUs("Witch Doctor")]
        WitchDoctor,
        [LocalizationEnUs("Wizard")]
        Wizard
    }
}