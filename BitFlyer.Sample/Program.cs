﻿using BitFlyer.Apis;
using System;

namespace BitFlyer.Sample.NETCore
{
    class Program
    {
        private static void Main()
        {
            var client = new RealtimeApi();
            var channelName = RealtimeChannel.TickerFxBtcJpy;
            client.Subscribe<Ticker>(channelName, OnReceive, OnConnect, OnError).Wait();

            Console.ReadKey();
        }

        private static void OnConnect()
        {
            Console.WriteLine("connected.");
        }

        private static void OnReceive(Ticker data)
        {
            Console.WriteLine(data.ToString());
        }

        private static void OnError(string message, Exception ex)
        {
            Console.WriteLine(message);
            if (ex != null)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
