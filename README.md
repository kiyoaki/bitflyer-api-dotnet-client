# bitflyer-api-dotnet-client

bitFlyer APIs Client Library for .NET https://lightning.bitflyer.jp/docs

[![Join the chat at https://gitter.im/bitflyer-api-dotnet-client/Lobby](https://badges.gitter.im/bitflyer-api-dotnet-client/Lobby.svg)](https://gitter.im/bitflyer-api-dotnet-client/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

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
        var apiClient = new PublicApi();

        Ticker ticker = apiClient.GetTicker(ProductCode.BtcJpy);
        
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
        var apiClient = new PrivateApi("{Your API Key}", "{Your API Secret}");
        
        PostResult result = await _apiClient.SendChildOrder(new SendChildOrderParameter
        {
            ProductCode = ProductCode.FxBtcJpy,
            ChildOrderType = ChildOrderType.Limit,
            Side = Side.Buy,
            Price = 10000,
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
        var client = new RealtimeApi();
        
        client.Subscribe<Ticker>(PubnubChannel.TickerFxBtcJpy, OnReceiveMessage, OnConnect, OnError);
        
        Console.ReadKey();
    }
    
    static void OnConnect(string message)
    {
        Console.WriteLine(message);
    }
    
    static void OnReceiveMessage(Ticker data)
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
