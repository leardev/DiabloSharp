using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class AccountConverter
    {
        private readonly Dictionary<string, CharacterClassIdentifier> _classIdentifierByClassId;

        public AccountConverter()
        {
            var characterClasses = Enum.GetValues(typeof(CharacterClassIdentifier))
                .Cast<CharacterClassIdentifier>()
                .ToList();
            _classIdentifierByClassId = new Dictionary<string, CharacterClassIdentifier>();

            foreach (var characterClass in characterClasses)
                _classIdentifierByClassId.Add(characterClass.ToDescription(), characterClass);
        }

        public Account AccountToModel(AccountDto account)
        {
            var paragonLevelsByGameMode = ParagonsToModel(account);
            var fallenHeroes = FallenHeroesToModel(account);

            var heroIds = HerosToModel(account)
                .ToList();
            var lastHeroId = LastHeroIdToModel(account.LastHeroPlayed, heroIds);

            return new Account
            {
                Id = account.BattleTag,
                Clan = account.GuildName,
                LastHeroId = lastHeroId,
                FallenHeroes = fallenHeroes,
                HeroIds = heroIds,
                ParagonLevelsByGameMode = paragonLevelsByGameMode
            };
        }

        private IEnumerable<HeroFallen> FallenHeroesToModel(AccountDto accountDto)
        {
            var fallenHeroes = new List<HeroFallen>();

            foreach (var fallenHeroDto in accountDto.FallenHeroes)
            {
                var gameMode = GameModeIdentifier.EraSoftcore;
                if (fallenHeroDto.Hardcore)
                    gameMode = GameModeIdentifier.EraHardcore;

                var fallenHero = new HeroFallen
                {
                    Id = new HeroIdentifier(fallenHeroDto.HeroId, fallenHeroDto.Name),
                    GameMode = gameMode,
                    Level = fallenHeroDto.Level,
                    Gender = (Gender) fallenHeroDto.Gender,
                    Class = _classIdentifierByClassId[fallenHeroDto.Class]
                };
                fallenHeroes.Add(fallenHero);
            }

            return fallenHeroes;
        }

        private HeroIdentifier LastHeroIdToModel(long accountLastHeroPlayed, IEnumerable<HeroIdentifier> heroIds)
        {
            if (accountLastHeroPlayed == 0)
                return HeroIdentifier.Empty;

            var heroId = heroIds.SingleOrDefault(x => x.Id == accountLastHeroPlayed);
            if (heroId == null)
                return HeroIdentifier.Empty;

            return heroId;
        }

        private IEnumerable<HeroIdentifier> HerosToModel(AccountDto accountDto)
        {
            var heroIds = new List<HeroIdentifier>();
            foreach (var heroDto in accountDto.Heroes)
            {
                var heroId = new HeroIdentifier(heroDto.Id, heroDto.Name);
                heroIds.Add(heroId);
            }
            return heroIds;
        }

        private IDictionary<GameModeIdentifier, long> ParagonsToModel(AccountDto accountDto)
        {
            return new Dictionary<GameModeIdentifier, long>
            {
                { GameModeIdentifier.EraSoftcore, accountDto.ParagonLevel },
                { GameModeIdentifier.EraHardcore, accountDto.ParagonLevelHardcore },
                { GameModeIdentifier.SeasonSoftcore, accountDto.ParagonLevelSeason },
                { GameModeIdentifier.SeasonHardcore, accountDto.ParagonLevelSeasonHardcore }
            };
        }
    }
}