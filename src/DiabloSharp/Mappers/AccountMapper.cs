using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class AccountMapper : Mapper<AccountDto, Account>
    {
        protected override void Map(AccountDto input, Account output)
        {
            var fallenHeroes = MapFallenHeroes(input.BattleTag, input.FallenHeroes);
            var era = MapEra(input);
            var heroes = MapHeroes(input.BattleTag, input.Heroes);
            var seasons = MapSeasons(input).ToList();
            var activeSeason = seasons.Single(season => season.IsActive);

            output.Id = new BattleTagId(input.BattleTag);
            output.Clan = input.GuildName;
            output.Era = era;
            output.ActiveSeason = activeSeason;
            output.Seasons = seasons;
            output.HeroIds = heroes;
            output.FallenHeros = fallenHeroes;
        }

        private IEnumerable<AccountFallenHero> MapFallenHeroes(string battleTag, IEnumerable<AccountFallenHeroDto> inputs)
        {
            var outputs = new List<AccountFallenHero>();
            foreach (var input in inputs)
            {
                var output = MapFallenHero(battleTag, input);
                outputs.Add(output);
            }

            return outputs;
        }

        private AccountFallenHero MapFallenHero(string battleTag, AccountFallenHeroDto input)
        {
            return new AccountFallenHero
            {
                Id = new HeroId(battleTag, input.HeroId),
                Name = input.Name,
                Level = input.Level,
                Gender = (HeroGender)input.Gender,
                Character = EnumConversionHelper.CharacterKindFromString(input.Class),
                IsDead = true
            };
        }

        private AccountPeriodEra MapEra(AccountDto input)
        {
            var eraDto = input.SeasonalProfiles.Season0;
            return new AccountPeriodEra
            {
                Id = AccountPeriodId.Era,
                Paragons = new[]
                {
                    new AccountPeriodParagon { Id = GameModeId.EraSoftcore, Value = eraDto.ParagonLevel },
                    new AccountPeriodParagon { Id = GameModeId.EraHardcore, Value = eraDto.ParagonLevelHardcore }
                },
                ArtisanLevels = new[]
                {
                    new AccountArtisanLevel { GameMode = GameModeId.EraSoftcore, ArtisanId = ArtisanId.Blacksmith, Level = input.Blacksmith.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.EraHardcore, ArtisanId = ArtisanId.Blacksmith, Level = input.BlacksmithHardcore.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.EraSoftcore, ArtisanId = ArtisanId.Jeweler, Level = input.Jeweler.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.EraHardcore, ArtisanId = ArtisanId.Jeweler, Level = input.JewelerHardcore.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.EraSoftcore, ArtisanId = ArtisanId.Mystic, Level = input.Mystic.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.EraHardcore, ArtisanId = ArtisanId.Mystic, Level = input.MysticHardcore.Level }
                }
            };
        }

        private IEnumerable<AccountPeriodSeason> MapSeasons(AccountDto input)
        {
            var activeSeason = ActiveSeasonToModel(input);
            var inactiveSeasons = InactiveSeasonsToModel(input);
            return new List<AccountPeriodSeason>(inactiveSeasons) { activeSeason };
        }

        private AccountPeriodSeason ActiveSeasonToModel(AccountDto input)
        {
            var seasonDto = input.SeasonalProfiles.Season18;
            return new AccountPeriodActiveSeason
            {
                Id = (AccountPeriodId)seasonDto.Id,
                IsActive = true,
                Paragons = new[]
                {
                    new AccountPeriodParagon { Id = GameModeId.SeasonSoftcore, Value = seasonDto.ParagonLevel },
                    new AccountPeriodParagon { Id = GameModeId.SeasonHardcore, Value = seasonDto.ParagonLevelHardcore }
                },
                ArtisanLevels = new[]
                {
                    new AccountArtisanLevel { GameMode = GameModeId.SeasonSoftcore, ArtisanId = ArtisanId.Blacksmith, Level = input.BlacksmithSeason.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.SeasonHardcore, ArtisanId = ArtisanId.Blacksmith, Level = input.BlacksmithSeasonHardcore.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.SeasonSoftcore, ArtisanId = ArtisanId.Jeweler, Level = input.JewelerSeason.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.SeasonHardcore, ArtisanId = ArtisanId.Jeweler, Level = input.JewelerSeasonHardcore.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.SeasonSoftcore, ArtisanId = ArtisanId.Mystic, Level = input.MysticSeason.Level },
                    new AccountArtisanLevel { GameMode = GameModeId.SeasonHardcore, ArtisanId = ArtisanId.Mystic, Level = input.MysticSeasonHardcore.Level }
                }
            };
        }

        private IEnumerable<AccountPeriodSeason> InactiveSeasonsToModel(AccountDto input)
        {
            var seasons = new List<AccountPeriodSeason>();

            var seasonsDto = new List<AccountSeasonProfileDto>
            {
                input.SeasonalProfiles.Season12,
                input.SeasonalProfiles.Season13,
                input.SeasonalProfiles.Season14,
                input.SeasonalProfiles.Season15,
                input.SeasonalProfiles.Season16
            };

            foreach (var seasonDto in seasonsDto)
            {
                var season = new AccountPeriodSeason
                {
                    Id = (AccountPeriodId)seasonDto.Id,
                    Paragons = new[]
                    {
                        new AccountPeriodParagon { Id = GameModeId.SeasonSoftcore, Value = seasonDto.ParagonLevel },
                        new AccountPeriodParagon { Id = GameModeId.SeasonHardcore, Value = seasonDto.ParagonLevelHardcore }
                    }
                };
                seasons.Add(season);
            }

            return seasons;
        }

        private IEnumerable<HeroId> MapHeroes(string battleTag, IEnumerable<AccountHeroDto> inputs)
        {
            var outputs = new List<HeroId>();
            foreach (var input in inputs)
            {
                var output = MapHero(battleTag, input);
                outputs.Add(output);
            }

            return outputs;
        }

        private HeroId MapHero(string battleTag, AccountHeroDto input)
        {
            return new HeroId(battleTag, input.Id);
        }
    }
}