using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedItemDto : ItemIdentifierDto
    {
        [DataMember(Name = "displayColor")]
        public string DisplayColor { get; set; }

        [DataMember(Name = "requiredLevel")]
        public long RequiredLevel { get; set; }

        [DataMember(Name = "itemLevel")]
        public long ItemLevel { get; set; }

        [DataMember(Name = "stackSizeMax")]
        public long StackSizeMax { get; set; }

        [DataMember(Name = "accountBound")]
        public bool AccountBound { get; set; }

        [DataMember(Name = "flavorText")]
        public string FlavorText { get; set; }

        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }

        [DataMember(Name = "type")]
        public DetailedItemKindDto Type { get; set; }

        [DataMember(Name = "armor")]
        public double Armor { get; set; }

        [DataMember(Name = "attacksPerSecond")]
        public double AttacksPerSecond { get; set; }

        [DataMember(Name = "minDamage")]
        public double MinDamage { get; set; }

        [DataMember(Name = "maxDamage")]
        public double MaxDamage { get; set; }

        [DataMember(Name = "elementalType")]
        public string ElementalType { get; set; }

        [DataMember(Name = "slots")]
        public string Slots { get; set; }

        [DataMember(Name = "augmentation")]
        public string Augmentation { get; set; }

        [DataMember(Name = "attributes")]
        public DetailedItemAttributesDto Attributes { get; set; }

        [DataMember(Name = "attributesHtml")]
        public DetailedItemAttributesDto AttributesHtml { get; set; }

        [DataMember(Name = "openSockets")]
        public long OpenSockets { get; set; }

        [DataMember(Name = "seasonRequiredToDrop")]
        public long SeasonRequiredToDrop { get; set; }

        [DataMember(Name = "isSeasonRequiredToDrop")]
        public bool IsSeasonRequiredToDrop { get; set; }

        [DataMember(Name = "dye")]
        public DetailedItemDyeDto Dye { get; set; }

        [DataMember(Name = "transmog")]
        public DetailedItemTransmogDto Transmog { get; set; }

        [DataMember(Name = "set")]
        public DetailedItemSetDto Set { get; set; }

        [DataMember(Name = "gems")]
        public IEnumerable<DetailedItemGemDto> Gems { get; set; }

        [DataMember(Name = "damage")]
        public string Damage { get; set; }

        [DataMember(Name = "dps")]
        public string Dps { get; set; }

        [DataMember(Name = "blockChance")]
        public string BlockChance { get; set; }

        [DataMember(Name = "craftedBy")]
        public DetailedItemRecipeDto CraftedBy { get; set; }
    }
}