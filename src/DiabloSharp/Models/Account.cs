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
        public int ParagonLevel { get; set; }

        [DataMember(Name = "paragonLevelHardcore")]
        public int ParagonLevelHardcore { get; set; }

        [DataMember(Name = "paragonLevelSeason")]
        public int ParagonLevelSeason { get; set; }

        [DataMember(Name = "paragonLevelSeasonHardcore")]
        public int ParagonLevelSeasonHardcore { get; set; }

        [DataMember(Name = "guildName")]
        public string GuildName { get; set; }

        [DataMember(Name = "heroes")]
        public IEnumerable<AccountHero> Heroes { get; set; }

        [DataMember(Name = "lastHeroPlayed")]
        public int LastHeroPlayed { get; set; }

        [DataMember(Name = "lastUpdated")]
        public int LastUpdated { get; set; }

        [DataMember(Name = "kills")]
        public AccountKills Kills { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public int HighestHardcoreLevel { get; set; }

        [DataMember(Name = "timePlayed")]
        public TimePlayed TimePlayed { get; set; }

        [DataMember(Name = "progression")]
        public Progression Progression { get; set; }

        [DataMember(Name = "fallenHeroes")]
        public IEnumerable<FallenHero> FallenHeroes { get; set; }

        [DataMember(Name = "seasonalProfiles")]
        public SeasonalProfiles SeasonalProfiles { get; set; }

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