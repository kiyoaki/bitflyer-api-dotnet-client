using System;
using Newtonsoft.Json;
using PubNubMessaging.Core;

namespace BitFlyer.Apis
{
    public class BitFlyerPubnubClient
    {
        private readonly Pubnub _pubnub;

        public BitFlyerPubnubClient()
        {
            _pubnub = new Pubnub("nopublishkey", BitFlyerConstants.SubscribeKey);
        }

        public void Subscribe<T>(PubnubChannel channel, Action<T> onMessageReceive, Action<string> onConnect, Action<string, Exception> onError)
        {
            _pubnub.Subscribe(
                channel.GetEnumMemberValue(),
                s => OnReceiveMessage(s, onMessageReceive, onError),
                onConnect,
                error =>
                {
                    onError(error.Message, error.DetailedDotNetException);
                });
        }

        private void OnReceiveMessage<T>(string result, Action<T> onMessageReceive, Action<string, Exception> onError)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                return;
            }

            var deserializedMessage = _pubnub.JsonPluggableLibrary.DeserializeToListOfObject(result);
            if (deserializedMessage == null || deserializedMessage.Count <= 0)
            {
                return;
            }

            var subscribedObject = deserializedMessage[0];
            if (subscribedObject == null)
            {
                return;
            }

            var resultActualMessage = _pubnub.JsonPluggableLibrary.SerializeToJsonString(subscribedObject);
            T deserialized;
            try
            {
                deserialized = JsonConvert.DeserializeObject<T>(resultActualMessage);
            }
            catch (Exception ex)
            {
                onError(ex.Message, ex);
                return;
            }
            onMessageReceive(deserialized);
        }
    }
}
