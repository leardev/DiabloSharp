using DiabloSharp.Attributes;

namespace DiabloSharp.Models
{
    public enum HeroStatId
    {
        [LocalizationEnUs("Life")]
        Life,
        [LocalizationEnUs("Damage")]
        Damage,
        [LocalizationEnUs("Toughness")]
        Toughness,
        [LocalizationEnUs("Healing")]
        Healing,
        [LocalizationEnUs("Attack Speed")]
        AttackSpeed,
        [LocalizationEnUs("Armor")]
        Armor,
        [LocalizationEnUs("Strength")]
        Strength,
        [LocalizationEnUs("Dexterity")]
        Dexterity,
        [LocalizationEnUs("Vitality")]
        Vitality,
        [LocalizationEnUs("Intelligence")]
        Intelligence,
        [LocalizationEnUs("Physical Resistance")]
        PhysicalResistance,
        [LocalizationEnUs("Fire Resistance")]
        FireResistance,
        [LocalizationEnUs("Cold Resistance")]
        ColdResistance,
        [LocalizationEnUs("Lightning Resistance")]
        LightningResistance,
        [LocalizationEnUs("Poison Resistance")]
        PoisonResistance,
        [LocalizationEnUs("Arcane Resistance")]
        ArcaneResistance,
        [LocalizationEnUs("Block Chance")]
        BlockChance,
        [LocalizationEnUs("Block Amount Minimum")]
        BlockAmountMinimum,
        [LocalizationEnUs("Block Amount Maximum")]
        BlockAmountMaximum,
        [LocalizationEnUs("Gold Find")]
        GoldFind,
        [LocalizationEnUs("Critical Hit Chance")]
        CriticalHitChance,
        [LocalizationEnUs("Thorns")]
        Thorns,
        [LocalizationEnUs("Life Steal")]
        LifeSteal,
        [LocalizationEnUs("Life per Kill")]
        LifePerKill,
        [LocalizationEnUs("Life per Hit")]
        LifePerHit,
        [LocalizationEnUs("Primary Resource")]
        PrimaryResource,
        [LocalizationEnUs("Secondary Resource")]
        SecondaryResource
    }
}