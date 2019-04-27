using System.ComponentModel;

namespace DiabloSharp.Models
{
    public enum CharacterClassIdentifier
    {
        [Description("barbarian")]
        Barbarian,
        [Description("crusader")]
        Crusader,
        [Description("demon-hunter")]
        DemonHunter,
        [Description("monk")]
        Monk,
        [Description("necromancer")]
        Necromancer,
        [Description("witch-doctor")]
        WitchDoctor,
        [Description("wizard")]
        Wizard
    }
}