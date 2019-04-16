using DiabloSharp;
using DiabloSharp.Configurations;
using System;
using System.Threading.Tasks;

namespace DiabloSharp.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DiabloSharp Demo");
            Console.WriteLine();
            DiabloSharpDemo().GetAwaiter().GetResult();
            Console.WriteLine();
            Console.ReadKey();
        }

        static async Task DiabloSharpDemo()
        {
            /*
             * var configuration = new DiabloApiConfiguration {
             *   ClientId = myBattleNetApiId,
             *   ClientSecret = myBattleNetApiSecret,
             *   Region = Region.Europe,
             *   Localization = Localization.EnglishUs
             * };
             */

            var configuration = new DiabloApiEnvironmentConfiguration();
            var api = new DiabloApi(configuration);
            var scope = api.CreateAuthenticationScope();
            var account = await api.Profile.GetAccountAsync(scope, "leehmanǃ-2543");

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
