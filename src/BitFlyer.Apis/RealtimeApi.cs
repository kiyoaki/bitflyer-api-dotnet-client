using PubNubMessaging.Core;
using System;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class RealtimeApi
    {
        private readonly Pubnub _pubnub;

        public RealtimeApi()
        {
            _pubnub = new Pubnub("nopublishkey", BitFlyerConstants.SubscribeKey);
        }

        public void Subscribe<T>(string channel, Action<T> onReceive, Action<string> onConnect, Action<string, Exception> onError)
        {
            _pubnub.Subscribe(
                channel,
                s => OnReceiveMessage(s, onReceive, onError),
                onConnect,
                error =>
                {
                    onError(error.Message, error.DetailedDotNetException);
                });
        }

        private void OnReceiveMessage<T>(string result, Action<T> onReceive, Action<string, Exception> onError)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                return;
            }

            var reader = new JsonReader(Encoding.UTF8.GetBytes(result));
            reader.ReadIsBeginArrayWithVerify();

            T deserialized;
            try
            {
                deserialized = JsonSerializer.Deserialize<T>(ref reader);
            }
            catch (Exception ex)
            {
                onError(ex.Message, ex);
                return;
            }
            onReceive(deserialized);
        }
    }
}
