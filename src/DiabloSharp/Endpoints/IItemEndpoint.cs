using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IItemEndpoint : IEndpoint
    {
        Task<ItemEquipment> GetEquipmentAsync(AuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemEquipment>> GetEquipmentsAsync(AuthenticationScope authenticationScope);

        Task<ItemGem> GetGemAsync(AuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemGem>> GetGemsAsync(AuthenticationScope authenticationScope);

        Task<ItemLegendaryGem> GetLegendaryGemAsync(AuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemLegendaryGem>> GetLegendaryGemsAsync(AuthenticationScope authenticationScope);

        Task<ItemLegendaryPotion> GetLegendaryPotionAsync(AuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemLegendaryPotion>> GetLegendaryPotionsAsync(AuthenticationScope authenticationScope);

        Task<ItemFollowerToken> GetFollowerTokenAsync(AuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemFollowerToken>> GetFollowerTokensAsync(AuthenticationScope authenticationScope);
    }
}