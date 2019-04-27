using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class AccountHeroConverter
    {
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
                    Gender = (Gender) fallenHeroDto.Gender,
                    Class = EnumConversionHelper.CharacterClassIdentifierFromSlug(fallenHeroDto.Class),
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