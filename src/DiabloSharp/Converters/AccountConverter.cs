using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class AccountConverter
    {
        private readonly AccountHeroConverter _heroConverter;

        private readonly AccountSeasonConverter _seasonConverter;

        public AccountConverter()
        {
            _seasonConverter = new AccountSeasonConverter();
            _heroConverter = new AccountHeroConverter();
        }

        public Account AccountToModel(AccountDto accountDto)
        {
            var fallenHeroes = _heroConverter.FallenHeroesToModel(accountDto);
            var era = _seasonConverter.EraToModel(accountDto);
            var heroes = _heroConverter.HeroesToModel(accountDto)
                .ToList();
            var seasons = _seasonConverter.SeasonsToModel(accountDto)
                .ToList();
            var activeSeason = seasons.Single(season => season.IsActive);

            return new Account
            {
                Id = new BattleTagIdentifier(accountDto.BattleTag),
                Clan = accountDto.GuildName,
                Era = era,
                ActiveSeason = activeSeason,
                Seasons = seasons,
                HeroIds = heroes,
                FallenHeros = fallenHeroes
            };
        }
    }
}