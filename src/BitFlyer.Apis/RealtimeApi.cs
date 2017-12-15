using PubnubApi;
using System;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class RealtimeApi
    {
        private readonly Pubnub _pubnub;

        public RealtimeApi()
        {
            var config = new PNConfiguration();
            config.SubscribeKey = BitFlyerConstants.SubscribeKey;
            config.PublishKey = "nopublishkey";
            _pubnub = new Pubnub(config);
        }

        public void Subscribe<T>(string channel, Action<T> onReceive, Action<string> onConnect, Action<string, Exception> onError)
        {
            _pubnub.AddListener(new SubscribeCallbackExt(
                (pubnubObj, message) =>
                {
                    if (message.Message is string json)
                    {
                        T deserialized;
                        try
                        {
                            deserialized = JsonSerializer.Deserialize<T>(json);
                            onReceive(deserialized);
                        }
                        catch (Exception ex)
                        {
                            onError(ex.Message, ex);
                            return;
                        }
                    }
                },
                (pubnubObj, presence) => { },
                (pubnubObj, status) =>
                {
                    if (status.Category == PNStatusCategory.PNUnexpectedDisconnectCategory)
                    {
                        onError("unexpected disconnect.", null);
                    }
                    else if (status.Category == PNStatusCategory.PNConnectedCategory)
                    {
                        onConnect("connected.");
                    }
                    else if (status.Category == PNStatusCategory.PNReconnectedCategory)
                    {
                        onError("reconnected.", null);
                    }
                    else if (status.Category == PNStatusCategory.PNDecryptionErrorCategory)
                    {
                        onError("messsage decryption error.", null);
                    }
                }
            ));

            _pubnub.Subscribe<string>()
                .Channels(new[] { channel })
                .Execute();
        }
    }
}
