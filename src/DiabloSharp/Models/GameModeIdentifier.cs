using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class GameModeIdentifier : ValueObject
    {
        private GameModeIdentifier(GameMode mode, GameModeDifficulty difficulty)
        {
            Mode = mode;
            Difficulty = difficulty;
        }

        public GameModeDifficulty Difficulty { get; }

        public GameMode Mode { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Difficulty;
            yield return Mode;
        }

        public override string ToString()
        {
            return $"{nameof(Mode)} = {Mode}, {nameof(Difficulty)} = {Difficulty}";
        }

        #region lookup-table

        public static GameModeIdentifier EraSoftcore { get; }

        public static GameModeIdentifier EraHardcore { get; }

        public static GameModeIdentifier SeasonSoftcore { get; }

        public static GameModeIdentifier SeasonHardcore { get; }

        public static GameModeIdentifier[] All { get; }

        static GameModeIdentifier()
        {
            EraSoftcore = new GameModeIdentifier(GameMode.Era, GameModeDifficulty.Softcore);
            EraHardcore = new GameModeIdentifier(GameMode.Era, GameModeDifficulty.Hardcore);
            SeasonSoftcore = new GameModeIdentifier(GameMode.Season, GameModeDifficulty.Softcore);
            SeasonHardcore = new GameModeIdentifier(GameMode.Season, GameModeDifficulty.Hardcore);
            All = new[]
            {
                EraSoftcore,
                EraHardcore,
                SeasonSoftcore,
                SeasonHardcore
            };
        }

        #endregion
    }
}