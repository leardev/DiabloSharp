using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class AccountDto
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
        public IEnumerable<AccountHeroDto> Heroes { get; set; }

        [DataMember(Name = "lastHeroPlayed")]
        public long LastHeroPlayed { get; set; }

        [DataMember(Name = "lastUpdated")]
        public long LastUpdated { get; set; }

        [DataMember(Name = "kills")]
        public AccountKillsDto Kills { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public long HighestHardcoreLevel { get; set; }

        [DataMember(Name = "timePlayed")]
        public AccountTimePlayedDto TimePlayed { get; set; }

        [DataMember(Name = "progression")]
        public AccountProgressionDto Progression { get; set; }

        [DataMember(Name = "fallenHeroes")]
        public IEnumerable<AccountFallenHeroDto> FallenHeroes { get; set; }

        [DataMember(Name = "seasonalProfiles")]
        public AccountSeasonProfilesDto SeasonalProfiles { get; set; }

        [DataMember(Name = "blacksmith")]
        public AccountArtisanDto Blacksmith { get; set; }

        [DataMember(Name = "jeweler")]
        public AccountArtisanDto Jeweler { get; set; }

        [DataMember(Name = "mystic")]
        public AccountArtisanDto Mystic { get; set; }

        [DataMember(Name = "blacksmithSeason")]
        public AccountArtisanDto BlacksmithSeason { get; set; }

        [DataMember(Name = "jewelerSeason")]
        public AccountArtisanDto JewelerSeason { get; set; }

        [DataMember(Name = "mysticSeason")]
        public AccountArtisanDto MysticSeason { get; set; }

        [DataMember(Name = "blacksmithHardcore")]
        public AccountArtisanDto BlacksmithHardcore { get; set; }

        [DataMember(Name = "jewelerHardcore")]
        public AccountArtisanDto JewelerHardcore { get; set; }

        [DataMember(Name = "mysticHardcore")]
        public AccountArtisanDto MysticHardcore { get; set; }

        [DataMember(Name = "blacksmithSeasonHardcore")]
        public AccountArtisanDto BlacksmithSeasonHardcore { get; set; }

        [DataMember(Name = "jewelerSeasonHardcore")]
        public AccountArtisanDto JewelerSeasonHardcore { get; set; }

        [DataMember(Name = "mysticSeasonHardcore")]
        public AccountArtisanDto MysticSeasonHardcore { get; set; }
    }
}