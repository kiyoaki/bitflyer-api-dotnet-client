using System;
using BitFlyer.Apis;

namespace BitFlyer.Pubnub.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new BitFlyerPubnubClient();

            //client.Subscribe<Board>(PubnubChannel.BoardSnapshotFxBtcJpy, OnReceiveMessage, OnConnect, OnError);
            //client.Subscribe<Board>(PubnubChannel.BoardFxBtcJpy, OnReceiveMessage, OnConnect, OnError);
            client.Subscribe<Ticker>(PubnubChannel.TickerFxBtcJpy, OnReceiveMessage, OnConnect, OnError);
            //client.Subscribe<PublicExecution[]>(PubnubChannel.ExecutionsFxBtcJpy, OnReceiveMessage, OnConnect, OnError);

            Console.ReadKey();
        }

        static void OnConnect(string message)
        {
            Console.WriteLine(message);
        }

        static void OnReceiveMessage(Board data)
        {
            Console.WriteLine(data);
        }

        static void OnReceiveMessage(Ticker data)
        {
            Console.WriteLine(data);
        }

        static void OnReceiveMessage(PublicExecution[] data)
        {
            foreach (var publicExecution in data)
            {
                Console.WriteLine(publicExecution);
            }
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
}
