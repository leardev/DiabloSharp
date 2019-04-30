using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class GameModeId : ValueObject
    {
        private GameModeId(GameMode mode, GameModeDifficulty difficulty)
        {
            Mode = mode;
            Difficulty = difficulty;
        }

        public GameModeDifficulty Difficulty { get; }

        public GameMode Mode { get; }

        public override string ToString()
        {
            return $"{nameof(Mode)} = {Mode}, {nameof(Difficulty)} = {Difficulty}";
        }

        #region lookup-table

        public static GameModeId EraSoftcore { get; }

        public static GameModeId EraHardcore { get; }

        public static GameModeId SeasonSoftcore { get; }

        public static GameModeId SeasonHardcore { get; }

        public static GameModeId[] All { get; }

        static GameModeId()
        {
            EraSoftcore = new GameModeId(GameMode.Era, GameModeDifficulty.Softcore);
            EraHardcore = new GameModeId(GameMode.Era, GameModeDifficulty.Hardcore);
            SeasonSoftcore = new GameModeId(GameMode.Season, GameModeDifficulty.Softcore);
            SeasonHardcore = new GameModeId(GameMode.Season, GameModeDifficulty.Hardcore);
            All = new[]
            {
                EraSoftcore,
                EraHardcore,
                SeasonSoftcore,
                SeasonHardcore
            };
        }

        #endregion

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Difficulty;
            yield return Mode;
        }
    }
}