using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Account
    {
        [DataMember(Name = "battleTag")]
        public string BattleTag { get; set; }

        [DataMember(Name = "paragonLevel")]
        public long ParagonLevel { get; set; }

        [DataMember(Name = "paragonLevelHardcore")]
        public long ParagonLevelHardcore { get; set; }

        [DataMember(Name = "paragonLevelSeason")]
        public long ParagonLevelSeason { get; set; }

        [DataMember(Name = "paragonLevelSeasonHardcore")]
        public long ParagonLevelSeasonHardcore { get; set; }

        [DataMember(Name = "guildName")]
        public string GuildName { get; set; }

        [DataMember(Name = "heroes")]
        public IEnumerable<AccountHero> Heroes { get; set; }

        [DataMember(Name = "lastHeroPlayed")]
        public long LastHeroPlayed { get; set; }

        [DataMember(Name = "lastUpdated")]
        public long LastUpdated { get; set; }

        [DataMember(Name = "kills")]
        public AccountKills Kills { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public long HighestHardcoreLevel { get; set; }

        [DataMember(Name = "timePlayed")]
        public AccountTimePlayed TimePlayed { get; set; }

        [DataMember(Name = "progression")]
        public AccountProgression Progression { get; set; }

        [DataMember(Name = "fallenHeroes")]
        public IEnumerable<AccountFallenHero> FallenHeroes { get; set; }

        [DataMember(Name = "seasonalProfiles")]
        public AccountSeasonProfiles SeasonalProfiles { get; set; }

        [DataMember(Name = "blacksmith")]
        public AccountArtisan Blacksmith { get; set; }

        [DataMember(Name = "jeweler")]
        public AccountArtisan Jeweler { get; set; }

        [DataMember(Name = "mystic")]
        public AccountArtisan Mystic { get; set; }

        [DataMember(Name = "blacksmithSeason")]
        public AccountArtisan BlacksmithSeason { get; set; }

        [DataMember(Name = "jewelerSeason")]
        public AccountArtisan JewelerSeason { get; set; }

        [DataMember(Name = "mysticSeason")]
        public AccountArtisan MysticSeason { get; set; }

        [DataMember(Name = "blacksmithHardcore")]
        public AccountArtisan BlacksmithHardcore { get; set; }

        [DataMember(Name = "jewelerHardcore")]
        public AccountArtisan JewelerHardcore { get; set; }

        [DataMember(Name = "mysticHardcore")]
        public AccountArtisan MysticHardcore { get; set; }

        [DataMember(Name = "blacksmithSeasonHardcore")]
        public AccountArtisan BlacksmithSeasonHardcore { get; set; }

        [DataMember(Name = "jewelerSeasonHardcore")]
        public AccountArtisan JewelerSeasonHardcore { get; set; }

        [DataMember(Name = "mysticSeasonHardcore")]
        public AccountArtisan MysticSeasonHardcore { get; set; }
    }
}