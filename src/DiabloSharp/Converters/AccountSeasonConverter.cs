using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class AccountSeasonConverter
    {
        public PeriodEra EraToModel(AccountDto accountDto)
        {
            var eraDto = accountDto.SeasonalProfiles.Season0;
            return new PeriodEra
            {
                Id = AccountPeriodIdentifier.Era,
                Paragons = new[]
                {
                    new PeriodParagon { Id = GameModeIdentifier.EraSoftcore, Value = eraDto.ParagonLevel },
                    new PeriodParagon { Id = GameModeIdentifier.EraHardcore, Value = eraDto.ParagonLevelHardcore }
                },
                ArtisanLevels = new[]
                {
                    new ArtisanLevel { GameMode = GameModeIdentifier.EraSoftcore, Artisan = ArtisanIdentifier.Blacksmith, Level = accountDto.Blacksmith.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.EraHardcore, Artisan = ArtisanIdentifier.Blacksmith, Level = accountDto.BlacksmithHardcore.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.EraSoftcore, Artisan = ArtisanIdentifier.Jeweler, Level = accountDto.Jeweler.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.EraHardcore, Artisan = ArtisanIdentifier.Jeweler, Level = accountDto.JewelerHardcore.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.EraSoftcore, Artisan = ArtisanIdentifier.Mystic, Level = accountDto.Mystic.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.EraHardcore, Artisan = ArtisanIdentifier.Mystic, Level = accountDto.MysticHardcore.Level }
                }
            };
        }

        public List<PeriodSeason> SeasonsToModel(AccountDto account)
        {
            var inactiveSeasons = InactiveSeasonsToModel(account);
            var activeSeason = ActiveSeasonToModel(account);
            return new List<PeriodSeason>(inactiveSeasons) { activeSeason };
        }

        private List<PeriodSeason> InactiveSeasonsToModel(AccountDto accountDto)
        {
            var seasons = new List<PeriodSeason>();

            var seasonsDto = new List<AccountSeasonProfileDto>
            {
                accountDto.SeasonalProfiles.Season12,
                accountDto.SeasonalProfiles.Season13,
                accountDto.SeasonalProfiles.Season14,
                accountDto.SeasonalProfiles.Season15
            };

            foreach (var seasonDto in seasonsDto)
            {
                var season = new PeriodSeason
                {
                    Id = (AccountPeriodIdentifier) seasonDto.Id,
                    Paragons = new[]
                    {
                        new PeriodParagon { Id = GameModeIdentifier.SeasonSoftcore, Value = seasonDto.ParagonLevel },
                        new PeriodParagon { Id = GameModeIdentifier.SeasonHardcore, Value = seasonDto.ParagonLevelHardcore }
                    }
                };
                seasons.Add(season);
            }

            return seasons;
        }

        private PeriodSeason ActiveSeasonToModel(AccountDto accountDto)
        {
            var seasonDto = accountDto.SeasonalProfiles.Season16;
            return new PeriodActiveSeason
            {
                Id = (AccountPeriodIdentifier) seasonDto.Id,
                IsActive = true,
                Paragons = new[]
                {
                    new PeriodParagon { Id = GameModeIdentifier.SeasonSoftcore, Value = seasonDto.ParagonLevel },
                    new PeriodParagon { Id = GameModeIdentifier.SeasonHardcore, Value = seasonDto.ParagonLevelHardcore }
                },
                ArtisanLevels = new[]
                {
                    new ArtisanLevel { GameMode = GameModeIdentifier.SeasonSoftcore, Artisan = ArtisanIdentifier.Blacksmith, Level = accountDto.BlacksmithSeason.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.SeasonHardcore, Artisan = ArtisanIdentifier.Blacksmith, Level = accountDto.BlacksmithSeasonHardcore.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.SeasonSoftcore, Artisan = ArtisanIdentifier.Jeweler, Level = accountDto.JewelerSeason.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.SeasonHardcore, Artisan = ArtisanIdentifier.Jeweler, Level = accountDto.JewelerSeasonHardcore.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.SeasonSoftcore, Artisan = ArtisanIdentifier.Mystic, Level = accountDto.MysticSeason.Level },
                    new ArtisanLevel { GameMode = GameModeIdentifier.SeasonHardcore, Artisan = ArtisanIdentifier.Mystic, Level = accountDto.MysticSeasonHardcore.Level }
                }
            };
        }
    }
}