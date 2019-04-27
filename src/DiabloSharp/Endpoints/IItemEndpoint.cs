using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IItemEndpoint : IEndpoint
    {
        Task<ItemEquipment> GetEquipmentAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemEquipment>> GetEquipmentsAsync(IAuthenticationScope authenticationScope);

        Task<ItemGem> GetGemAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemGem>> GetGemsAsync(IAuthenticationScope authenticationScope);

        Task<ItemLegendaryGem> GetLegendaryGemAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemLegendaryGem>> GetLegendaryGemsAsync(IAuthenticationScope authenticationScope);

        Task<ItemLegendaryPotion> GetLegendaryPotionAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemLegendaryPotion>> GetLegendaryPotionsAsync(IAuthenticationScope authenticationScope);

        Task<ItemFollowerToken> GetFollowerTokenAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier);

        Task<IEnumerable<ItemFollowerToken>> GetFollowerTokensAsync(IAuthenticationScope authenticationScope);
    }
}