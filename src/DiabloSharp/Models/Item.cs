using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Item
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "tooltipParams")]
        public string TooltipParams { get; set; }

        [DataMember(Name = "requiredLevel")]
        public long RequiredLevel { get; set; }

        [DataMember(Name = "stackSizeMax")]
        public long StackSizeMax { get; set; }

        [DataMember(Name = "accountBound")]
        public bool AccountBound { get; set; }

        [DataMember(Name = "flavorText")]
        public string FlavorText { get; set; }

        [DataMember(Name = "flavorTextHtml")]
        public string FlavorTextHtml { get; set; }

        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }

        [DataMember(Name = "type")]
        public ItemKind Type { get; set; }

        [DataMember(Name = "armor")]
        public string Armor { get; set; }

        [DataMember(Name = "armorHtml")]
        public string ArmorHtml { get; set; }

        [DataMember(Name = "block")]
        public string Block { get; set; }

        [DataMember(Name = "blockHtml")]
        public string BlockHtml { get; set; }

        [DataMember(Name = "damage")]
        public string Damage { get; set; }

        [DataMember(Name = "dps")]
        public string Dps { get; set; }

        [DataMember(Name = "damageHtml")]
        public string DamageHtml { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "descriptionHtml")]
        public string DescriptionHtml { get; set; }

        [DataMember(Name = "isSeasonRequiredToDrop")]
        public bool IsSeasonRequiredToDrop { get; set; }

        [DataMember(Name = "seasonRequiredToDrop")]
        public long SeasonRequiredToDrop { get; set; }

        [DataMember(Name = "slots")]
        public IEnumerable<string> Slots { get; set; }

        [DataMember(Name = "attributes")]
        public ItemAttributes Attributes { get; set; }

        [DataMember(Name = "randomAffixes")]
        public IEnumerable<ItemRandomAffix> RandomAffixes { get; set; }

        [DataMember(Name = "setName")]
        public string SetName { get; set; }

        [DataMember(Name = "setNameHtml")]
        public string SetNameHtml { get; set; }

        [DataMember(Name = "setDescription")]
        public string SetDescription { get; set; }

        [DataMember(Name = "setDescriptionHtml")]
        public string SetDescriptionHtml { get; set; }

        [DataMember(Name = "setItems")]
        public IEnumerable<string> SetItems { get; set; }
    }
}