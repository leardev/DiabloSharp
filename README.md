# DiabloSharp - A .NET Implementation of the Battle.net Diablo API

Builds: [![Build status](https://ci.appveyor.com/api/projects/status/0m4s09bni1u30vt3/branch/master?svg=true)](https://ci.appveyor.com/project/leehmanQQ/diablosharp/branch/master)

NuGet: [![Build status](https://img.shields.io/nuget/v/DiabloSharp.svg)](https://www.nuget.org/packages/DiabloSharp/)

## NuGet

You can add the API to your project via nuget-package:

```Shell
Install-Package DiabloSharp

//or

Install-Package DiabloSharp -pre
```

## Example

You can find a sample project under `.\samples`.

```c#
using DiabloSharp;
using DiabloSharp.Configurations;
using System;
using System.Threading.Tasks;

namespace DiabloSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DiabloSharp Demo");
            Console.WriteLine();
            DiabloSharpDemo().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task DiabloSharpDemo()
        {
            var configuration = new DiabloApiEnvironmentConfiguration();
            var api = new DiabloApi(configuration);
            var scope = api.CreateAuthenticationScope();
            var account = await api.Profile.GetAccountAsync(scope, "leehmanǃ-2543");

            Console.WriteLine($"Queried account information for BattleTag {account.BattleTag}");
        }
    }
}
```
