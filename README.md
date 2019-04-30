# DiabloSharp - A .NET Implementation of the Battle.net Diablo API

Builds: [![Build status](https://ci.appveyor.com/api/projects/status/0m4s09bni1u30vt3/branch/master?svg=true)](https://ci.appveyor.com/project/leehmanQQ/diablosharp/branch/master)

NuGet: [![Build status](https://img.shields.io/nuget/v/DiabloSharp.svg)](https://www.nuget.org/packages/DiabloSharp/)

Coverage: [![codecov](https://codecov.io/gh/leardev/DiabloSharp/branch/master/graph/badge.svg)](https://codecov.io/gh/leardev/DiabloSharp)

## NuGet

You can add the API to your project via nuget-package:

```Shell
Install-Package DiabloSharp

//or

Install-Package DiabloSharp -pre
```

## Example

You can find more samples under `.\samples`.

```c#
var configuration = new DiabloApiConfiguration
{
    ClientId = "YOUR_BATTLE_NET_CLIENT_ID",
    ClientSecret = "YOUR_BATTLE_NET_CLIENT_SECRET",
    Region = Region.Europe,
    Localization = Localization.EnglishUs
};

var api = new DiabloApi(configuration);
var authenticationScope = await api.CreateAuthenticationScopeAsync();
var battleTagId = new BattleTagId("BATTLE_TAG_NAME#BATTLE_TAG_ID");
var account = await api.Profile.GetAccountAsync(authenticationScope, battleTagId);
```
