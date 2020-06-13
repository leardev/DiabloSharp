using System;
using System.Collections.Generic;
using DiabloSharp.Extensions;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class SoloLeaderboardId : ValueObject
    {
        public SeasonId SeasonId { get; internal set; }

        public CharacterKind CharacterId { get; internal set; }

        public bool IsHardcore { get; internal set; }

        public string ToSlug()
        {
            var identifier = "rift";

            if (IsHardcore)
                identifier = identifier.Combine("hardcore", "-");

            switch (CharacterId)
            {
                case CharacterKind.Barbarian:
                    return identifier.Combine("barbarian", "-");
                case CharacterKind.Crusader:
                    return identifier.Combine("crusader", "-");
                case CharacterKind.DemonHunter:
                    return identifier.Combine("dh", "-");
                case CharacterKind.Monk:
                    return identifier.Combine("monk", "-");
                case CharacterKind.Necromancer:
                    return identifier.Combine("necromancer", "-");
                case CharacterKind.WitchDoctor:
                    return identifier.Combine("wd", "-");
                case CharacterKind.Wizard:
                    return identifier.Combine("wizard", "-");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"{nameof(SeasonId)} = {SeasonId}, {nameof(CharacterId)} = {CharacterId}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return SeasonId;
            yield return CharacterId;
            yield return IsHardcore;
        }
    }
}