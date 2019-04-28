using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IItemEndpoint : IEndpoint
    {
        Task<ItemEquipment> GetEquipmentAsync(IAuthenticationScope authenticationScope, ItemId itemId);

        Task<IEnumerable<ItemEquipment>> GetEquipmentsAsync(IAuthenticationScope authenticationScope);

        Task<ItemGem> GetGemAsync(IAuthenticationScope authenticationScope, ItemId itemId);

        Task<IEnumerable<ItemGem>> GetGemsAsync(IAuthenticationScope authenticationScope);

        Task<ItemLegendaryGem> GetLegendaryGemAsync(IAuthenticationScope authenticationScope, ItemId itemId);

        Task<IEnumerable<ItemLegendaryGem>> GetLegendaryGemsAsync(IAuthenticationScope authenticationScope);

        Task<ItemLegendaryPotion> GetLegendaryPotionAsync(IAuthenticationScope authenticationScope, ItemId itemId);

        Task<IEnumerable<ItemLegendaryPotion>> GetLegendaryPotionsAsync(IAuthenticationScope authenticationScope);

        Task<ItemFollowerToken> GetFollowerTokenAsync(IAuthenticationScope authenticationScope, ItemId itemId);

        Task<IEnumerable<ItemFollowerToken>> GetFollowerTokensAsync(IAuthenticationScope authenticationScope);
    }
}