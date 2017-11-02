# bitflyer-api-dotnet-client

bitFlyer APIs Client Library for .NET https://lightning.bitflyer.jp/docs

[![Build status](https://ci.appveyor.com/api/projects/status/ejbfftj9qdkc69mp/branch/master?svg=true)](https://ci.appveyor.com/project/kiyoaki/bitflyer-api-dotnet-client/branch/master)

Install
---
for .NET, .NET Core

* PM> Install-Package [BitFlyer.Apis](https://www.nuget.org/packages/BitFlyer.Apis)

Quick Start
---
### HTTP Public API

```
class Program
{
    static void Main(string[] args)
    {
        Ticker ticker = PublicApi.GetTicker(ProductCode.BtcJpy).Result;
        
        Console.WriteLine(ticker);
        Console.ReadKey();
    }
}
```

### HTTP Private API

You can create API Key and API Secret here.
https://lightning.bitflyer.jp/developer

```
class Program
{
    static void Main(string[] args)
    {
        var api = new PrivateApi("{Your API Key}", "{Your API Secret}");
        
        var result = api.SendChildOrder(new SendChildOrderParameter
        {
            ProductCode = ProductCode.FxBtcJpy,
            ChildOrderType = ChildOrderType.Limit,
            Side = Side.Buy,
            Price = 10000,
            Size = 0.01,
            MinuteToExpire = 10000,
            TimeInForce = TimeInForce.GoodTilCanceled
        }).Result;
        
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
```

### Realtime API

```csharp
class Program
{
    static void Main(string[] args)
    {
        var api = new RealtimeApi();
        
        api.Subscribe<Ticker>(PubnubChannel.TickerFxBtcJpy, OnReceive, OnConnect, OnError);
        
        Console.ReadKey();
    }
    
    static void OnConnect(string message)
    {
        Console.WriteLine(message);
    }
    
    static void OnReceive(Ticker data)
    {
        Console.WriteLine(data);
    }
    
    static void OnError(string message, Exception ex)
    {
        Console.WriteLine(message);
        if (ex != null)
        {
            Console.WriteLine(ex);
        }
    }
}
```

---
