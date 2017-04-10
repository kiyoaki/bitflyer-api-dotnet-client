using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BitFlyer.Apis;
using Newtonsoft.Json;

namespace BitFlyer.Sample
{
    class Program
    {
        private static readonly Uri OkcoinUri = new Uri("wss://real.okcoin.cn:10440/websocket/okcoinapi");
        private static readonly CancellationToken CancellationToken = new CancellationToken();

        private static volatile OkCoin.TickerItem _latestOkCoinTicker;
        private static volatile Ticker _latestBitFlyerTicker;

        private static DateTime _lastReceiveBitFlyer = DateTime.UtcNow;
        private static DateTime _lastReceiveOkCoin = DateTime.UtcNow;

        private static void Main()
        {
            var client = new RealtimeApi();

            client.Subscribe<Ticker>(PubnubChannel.TickerFxBtcJpy, OnReceiveBitFlyer, OnConnect, OnError);
            SubscribeOkCoin(CancellationToken).FireAndForget();
            Core();

            Console.ReadKey();
        }

        private static void OnConnect(string message)
        {
            Console.WriteLine(message);
        }

        private static void OnReceiveBitFlyer(Ticker data)
        {
            _lastReceiveBitFlyer = DateTime.UtcNow;
            _latestBitFlyerTicker = data;
        }

        private static void OnError(string message, Exception ex)
        {
            Console.WriteLine(message);
            if (ex != null)
            {
                Console.WriteLine(ex);
            }
        }

        private static Task SubscribeOkCoin(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(async () =>
            {
                var okCoinWebSocket = new ClientWebSocket();
                okCoinWebSocket.Options.KeepAliveInterval = TimeSpan.FromMinutes(1);
                await okCoinWebSocket.ConnectAsync(OkcoinUri, cancellationToken);
                while (okCoinWebSocket.State == WebSocketState.Connecting)
                {
                    Console.WriteLine("Waiting WebSocket connnet......");
                    Thread.Sleep(1000);
                }

                var addChannel = Encoding.UTF8.GetBytes("{'event':'addChannel','channel':'ok_sub_spotcny_btc_ticker'}");
                var tickerSubscriptionMessage = new ArraySegment<byte>(addChannel);
                await okCoinWebSocket.SendAsync(tickerSubscriptionMessage, WebSocketMessageType.Text, false, cancellationToken);

                var buffer = new byte[4096];
                var seg = new ArraySegment<byte>(buffer);

                while (okCoinWebSocket.State == WebSocketState.Open)
                {
                    var result = await okCoinWebSocket.ReceiveAsync(seg, cancellationToken);
                    var bytes = seg.Array.Take(result.Count).ToArray();

                    var array = JsonConvert.DeserializeObject<OkCoin.Ticker[]>(Encoding.UTF8.GetString(bytes));
                    if (array != null && array.Length > 0 && array.Any(x => x.Data != null))
                    {
                        var ticker = array.MaxBy(x => x.Data.Unixtime);
                        if (ticker.Data != null)
                        {
                            OnReceiveOkCoin(ticker.Data);
                        }
                    }
                }

                okCoinWebSocket.Dispose();

            }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private static void OnReceiveOkCoin(OkCoin.TickerItem data)
        {
            _lastReceiveOkCoin = DateTime.UtcNow;
            _latestOkCoinTicker = data;
        }

        private static void Core()
        {
            while (true)
            {
                var now = DateTime.UtcNow;
                if (now - _lastReceiveOkCoin > TimeSpan.FromSeconds(5))
                {
                    SubscribeOkCoin(CancellationToken).FireAndForget();
                }

                if (now - _lastReceiveBitFlyer < TimeSpan.FromSeconds(5)
                    && now - _lastReceiveOkCoin < TimeSpan.FromSeconds(5)
                    && _latestBitFlyerTicker != null
                    && _latestOkCoinTicker != null)
                {
                    try
                    {
                        Console.WriteLine("bitFlyer latest price: " + _latestBitFlyerTicker.LatestPrice);
                        Console.WriteLine("OkCoin   latest price: " + _latestOkCoinTicker.Last);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Thread.Sleep(1000);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }

    public static class Extensions
    {
        public static void FireAndForget(this Task task)
        {
            task.ConfigureAwait(false);
            task.ContinueWith(x =>
            {
                Console.WriteLine(x.Exception != null
                    ? $"TaskUnhandled: {x.Exception.Message}"
                    : "TaskUnhandled");

            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return MaxBy(source, keySelector, Comparer<TKey>.Default);
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            return ExtremaBy(source, keySelector, comparer.Compare);
        }

        private static TSource ExtremaBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            Func<TKey, TKey, int> comparer)
        {
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) throw new InvalidOperationException("sequence contains no element");

                TSource current = e.Current;
                TKey currentKey = keySelector(current);
                while (e.MoveNext())
                {
                    TSource next = e.Current;
                    TKey nextKey = keySelector(next);
                    if (comparer(currentKey, nextKey) < 0)
                    {
                        current = next;
                        currentKey = nextKey;
                    }
                }

                return current;
            }
        }
    }
}
