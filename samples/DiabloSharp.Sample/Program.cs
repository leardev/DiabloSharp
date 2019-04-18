using DiabloSharp.Configurations;
using DiabloSharp.Models;
using System;
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
            const string battleTag = "leehmanǃ-2543";
            var configuration = new DiabloApiConfiguration
            {
                ClientId = "YOUR_BATTLE_NET_CLIENT_ID",
                ClientSecret = "YOUR_BATTLE_NET_CLIENT_SECRET",
                Region = Region.Europe,
                Localization = Localization.EnglishUs
            };

            var api = new DiabloApi(configuration);
            var scope = await api.CreateAuthenticationScopeAsync();
            var account = await api.Profile.GetAccountAsync(scope, battleTag);

            Console.WriteLine($"Queried account for BattleTag {account.BattleTag}");
            foreach (var hero in account.Heroes)
            {
                var gender = hero.Gender == 1 ? "female" : "male";
                var seasonal = hero.Seasonal ? "seasonal" : "non season";
                var hardcore = hero.Hardcore ? "hardcore" : "softcore";
                Console.WriteLine($"The {seasonal} hero {hero.Name} ({gender} {hero.Class}) " +
                    $"has {hero.Kills.Elites} elite kills on {hardcore}.");
            }
        }
    }
}
