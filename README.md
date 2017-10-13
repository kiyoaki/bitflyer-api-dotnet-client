# bitflyer-api-dotnet-client

bitFlyer APIs Client Library for .NET https://lightning.bitflyer.jp/docs

Install
---
for .NET, .NET Core

* PM> Install-Package [BitFlyer.Apis](https://www.nuget.org/packages/BitFlyer.Apis)

Quick Start
---
HTTP Public API

```csharp
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

HTTP Private API

You can create API Key and API Secret here.
https://lightning.bitflyer.jp/developer

```csharp
class Program
{
    static void Main(string[] args)
    {
        var api = new PrivateApi("{Your API Key}", "{Your API Secret}");
        
        PostResult result = await api.SendChildOrder(new SendChildOrderParameter
        {
            ProductCode = ProductCode.FxBtcJpy,
            ChildOrderType = ChildOrderType.Limit,
            Side = Side.Buy,
            Price = 600000,
            Size = 0.01,
            MinuteToExpire = 10000,
            TimeInForce = TimeInForce.GoodTilCanceled
        });
        
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
```

Realtime API

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
