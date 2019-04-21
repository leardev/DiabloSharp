using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Features;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class GemConverter
    {
        private readonly Dictionary<string, ItemQuality> _qualityByText;

        public GemConverter()
        {
            #region qualityByText

            _qualityByText = new Dictionary<string, ItemQuality>
            {
                { "white", ItemQuality.Common },
                { "blue", ItemQuality.Magic },
                { "yellow", ItemQuality.Rare },
                { "orange", ItemQuality.Legendary },
                { "green", ItemQuality.Set }
            };

            #endregion
        }

        public Gem ItemToModel(ItemDto itemDto)
        {
            var tooltip = new Tooltip
            {
                Description = itemDto.Description,
                DescriptionHtml = itemDto.DescriptionHtml,
                FlavorText = itemDto.FlavorText,
                FlavorTextHtml = itemDto.FlavorTextHtml,
                IconUrl = itemDto.Icon,
                Url = itemDto.TooltipParams
            };

            var gem = new Gem
            {
                Id = new ItemIdentifier(itemDto.Id, itemDto.Slug),
                Name = itemDto.Name,
                Tooltip = tooltip,
                RequiredLevel = itemDto.RequiredLevel,
                AccountBound = itemDto.AccountBound,
                IsSeasonRequiredToDrop = itemDto.IsSeasonRequiredToDrop,
                SeasonRequiredToDrop = itemDto.SeasonRequiredToDrop,
                Quality = _qualityByText[itemDto.Color]
            };

            if (itemDto.Attributes != null)
            {
                var itemAttributesFeature = AttributesToModel(itemDto.Attributes);
                gem.AddFeature(itemAttributesFeature);
            }

            return gem;
        }
        
        private ItemAttributesFeature AttributesToModel(ItemAttributesDto itemAttributesDto)
        {
            var primary = itemAttributesDto.Primaries.Select(AttributeToModel);
            var secondary = itemAttributesDto.Secondaries.Select(AttributeToModel);
            var other = itemAttributesDto.Others.Select(AttributeToModel);

            return new ItemAttributesFeature
            {
                Primary = primary,
                Secondary = secondary,
                Other = other
            };
        }

        private ItemAttribute AttributeToModel(ItemHtmlDescriptionDto itemHtmlDescriptionDto)
        {
            return new ItemAttribute
            {
                Text = itemHtmlDescriptionDto.Text,
                TextHtml = itemHtmlDescriptionDto.TextHtml
            };
        }

        public IEnumerable<Gem> ItemsToModel(IEnumerable<ItemDto> itemDtos)
        {
            return itemDtos.Select(ItemToModel);
        }
    }
}