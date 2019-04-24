using System.Collections.Generic;
using DiabloSharp.Exceptions;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class BattleTagIdentifier : ValueObject
    {
        public BattleTagIdentifier(string battleTag)
        {
            /* todo find a better way */
            var parts = battleTag.Split('#');

            if (parts.Length != 2)
                throw new DiabloApiBattleTagException(battleTag);
            if (!long.TryParse(parts[1], out var index))
                throw new DiabloApiBattleTagException(battleTag);
            Index = index;
            Name = parts[0];
        }

        public BattleTagIdentifier(string name, long index)
        {
            Index = index;
            Name = name;
        }

        public string Name { get; }

        public long Index { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Index;
            yield return Name;
        }

        public override string ToString()
        {
            return $"{Name}#{Index}";
        }
    }
}