using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Clients
{
    internal class BattleNetClient : HttpClientBase
    {
        public BattleNetClient(string accessToken, string region, string localization, ITokenBucket tokenBucket) : base($"https://{region}.api.blizzard.com", tokenBucket)
        {
            AddParameter("access_token", accessToken);
            AddParameter("locale", localization);
        }

        #region Follower

        public Task<FollowerDto> GetFollowerAsync(string followerSlug)
        {
            return GetAsync<FollowerDto>($"/d3/data/follower/{followerSlug}");
        }

        #endregion

        #region Item

        public Task<ItemDto> GetItemAsync(string itemTypePath)
        {
            return GetAsync<ItemDto>($"d3/data/{itemTypePath}");
        }

        #endregion

        #region Act

        public Task<ActIndexDto> GetActIndexAsync()
        {
            return GetAsync<ActIndexDto>("/d3/data/act");
        }

        public Task<ActDto> GetActAsync(long actId)
        {
            return GetAsync<ActDto>($"/d3/data/act/{actId}");
        }

        #endregion

        #region Artisan

        public Task<ArtisanDto> GetArtisanAsync(string artisanSlug)
        {
            return GetAsync<ArtisanDto>($"d3/data/artisan/{artisanSlug}");
        }

        public Task<RecipeDto> GetRecipeAsync(string artisanSlug, string recipeSlug)
        {
            return GetAsync<RecipeDto>($"d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}");
        }

        #endregion

        #region Character

        public Task<CharacterClassDto> GetCharacterClassAsync(string classSlug)
        {
            return GetAsync<CharacterClassDto>($"/d3/data/hero/{classSlug}");
        }

        public Task<CharacterApiSkillDto> GetApiSkillAsync(string classSlug, string skillSlug)
        {
            return GetAsync<CharacterApiSkillDto>($"/d3/data/hero/{classSlug}/skill/{skillSlug}");
        }

        #endregion

        #region Era

        public Task<EraIndexDto> GetEraIndexAsync()
        {
            return GetAsync<EraIndexDto>("/data/d3/era/");
        }

        public Task<EraDto> GetEraAsync(long eraId)
        {
            return GetAsync<EraDto>($"/data/d3/era/{eraId}");
        }

        public Task<EraLeaderboardDetailDto> GetEraLeaderboardAsync(long eraId, string leaderboardId)
        {
            return GetAsync<EraLeaderboardDetailDto>($"/data/d3/era/{eraId}/leaderboard/{leaderboardId}");
        }

        #endregion

        #region ItemType

        public Task<IEnumerable<ItemTypeIndexDto>> GetItemTypeIndexAsync()
        {
            return GetAsync<IEnumerable<ItemTypeIndexDto>>("d3/data/item-type");
        }

        public Task<IEnumerable<ItemTypeDto>> GetItemTypeAsync(string itemTypeIndexPath)
        {
            return GetAsync<IEnumerable<ItemTypeDto>>($"d3/data/{itemTypeIndexPath}");
        }

        #endregion

        #region Profile

        public Task<AccountDto> GetAccountAsync(string battleTag)
        {
            return GetAsync<AccountDto>($"d3/profile/{battleTag}/");
        }

        public Task<HeroDto> GetHeroAsync(string battleTag, long heroId)
        {
            return GetAsync<HeroDto>($"d3/profile/{battleTag}/hero/{heroId}");
        }

        public Task<DetailedHeroItemsDto> GetDetailedHeroItemsAsync(string battleTag, long heroId)
        {
            return GetAsync<DetailedHeroItemsDto>($"/d3/profile/{battleTag}/hero/{heroId}/items");
        }

        public Task<DetailedFollowersDto> GetDetailedFollowerItemsAsync(string battleTag, long heroId)
        {
            return GetAsync<DetailedFollowersDto>($"/d3/profile/{battleTag}/hero/{heroId}/follower-items");
        }

        #endregion

        #region Season

        public Task<SeasonIndexDto> GetSeasonIndexAsync()
        {
            return GetAsync<SeasonIndexDto>("/data/d3/season/");
        }

        public Task<SeasonDto> GetSeasonAsync(long seasonId)
        {
            return GetAsync<SeasonDto>($"/data/d3/season/{seasonId}");
        }

        public Task<SeasonLeaderboardDetailDto> GetSeasonLeaderboardAsync(long seasonId, string leaderboardId)
        {
            return GetAsync<SeasonLeaderboardDetailDto>($"/data/d3/season/{seasonId}/leaderboard/{leaderboardId}");
        }

        #endregion
    }
}