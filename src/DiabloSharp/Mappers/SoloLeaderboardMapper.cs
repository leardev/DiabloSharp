using System;
using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Endpoints;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class SoloLeaderboardMapper : Mapper<SeasonLeaderboardDetailDto, SoloLeaderboard>
    {
        private readonly SoloLeaderboardId _leaderboardId;

        public SoloLeaderboardMapper(SoloLeaderboardId leaderboardId)
        {
            _leaderboardId = leaderboardId;
        }

        protected override void Map(SeasonLeaderboardDetailDto input, SoloLeaderboard output)
        {
            var ranks = new List<SoloRank>();
            foreach (var row in input.Rows)
            {
                var player = row.Players.Single();
                var playerDataById = player.Datas.ToDictionary(dto => dto.Id);
                var rowDataById = row.Datas.ToDictionary(dto => dto.Id);

                var heroId = new HeroId(playerDataById["HeroBattleTag"].String, playerDataById["HeroId"].Number.Value);

                var duration = TimeSpan.FromMilliseconds(rowDataById["RiftTime"].Timestamp.Value);
                var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(rowDataById["CompletedTime"].Timestamp.Value);
                var timestamp = dateTimeOffset.UtcDateTime;

                var rank = new SoloRank
                {
                    Id = heroId,
                    Rank = rowDataById["Rank"].Number.Value,
                    Tier = rowDataById["RiftLevel"].Number.Value,
                    Duration = duration,
                    Timestamp = timestamp,
                    Paragon = playerDataById["ParagonLevel"].Number.Value
                };
                ranks.Add(rank);
            }

            output.Id = _leaderboardId;
            output.Ranks = ranks;
        }
    }
}