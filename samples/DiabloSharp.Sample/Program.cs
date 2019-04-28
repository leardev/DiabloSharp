using DiabloSharp.Configurations;
using DiabloSharp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiabloSharp.Sample
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("DiabloSharp Demo");
            Console.WriteLine();
            await QueryHeroesFromBattleTagExampleAsync();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        private static async Task QueryHeroesFromBattleTagExampleAsync()
        {
            var battleTagId = new BattleTagIdentifier("leehmanǃ#2543");
            var configuration = new DiabloApiConfiguration
            {
                ClientId = "YOUR_BATTLE_NET_CLIENT_ID",
                ClientSecret = "YOUR_BATTLE_NET_CLIENT_SECRET",
                Region = Region.Europe,
                Localization = Localization.EnglishUs
            };

            var diabloApi = new DiabloApi(configuration);
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();
            var account = await diabloApi.Profile.GetAccountAsync(authenticationScope, battleTagId);

            Console.WriteLine($"Queried account for BattleTag {account.Id}");
            foreach (var heroId in account.HeroIds)
            {
                var hero = await diabloApi.Profile.GetHeroAsync(authenticationScope, heroId);
                var stats = hero.Stats
                    .OrderByDescending(stat => stat.Value)
                    .Take(5);

                Console.WriteLine($"{hero.Name} ({hero.Gender} {hero.Character})");
                foreach (var stat in stats)
                    Console.WriteLine($"\t{stat.Id}");
            }
        }
    }
}
