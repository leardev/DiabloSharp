using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class AccountHeroConverter
    {
        private readonly Dictionary<string, CharacterClassIdentifier> _classIdentifierByClassId;

        public AccountHeroConverter()
        {
            var characterClasses = Enum.GetValues(typeof(CharacterClassIdentifier))
                .Cast<CharacterClassIdentifier>()
                .ToList();
            _classIdentifierByClassId = new Dictionary<string, CharacterClassIdentifier>();

            foreach (var characterClass in characterClasses)
                _classIdentifierByClassId.Add(characterClass.ToDescription(), characterClass);
        }

        public List<HeroFallen> FallenHeroesToModel(AccountDto accountDto)
        {
            var fallenHeroes = new List<HeroFallen>();

            foreach (var fallenHeroDto in accountDto.FallenHeroes)
            {
                var fallenHero = new HeroFallen
                {
                    Id = new HeroIdentifier(accountDto.BattleTag, fallenHeroDto.HeroId),
                    Name = fallenHeroDto.Name,
                    Level = fallenHeroDto.Level,
                    Gender = (Gender)fallenHeroDto.Gender,
                    Class = _classIdentifierByClassId[fallenHeroDto.Class],
                    IsDead = true
                };
                fallenHeroes.Add(fallenHero);
            }

            return fallenHeroes;
        }

        public List<HeroIdentifier> HeroesToModel(AccountDto accountDto)
        {
            var heroeIds = new List<HeroIdentifier>();
            foreach (var heroDto in accountDto.Heroes)
            {
                var hero = new HeroIdentifier(accountDto.BattleTag, heroDto.Id);
                heroeIds.Add(hero);
            }

            return heroeIds;
        }
    }
}