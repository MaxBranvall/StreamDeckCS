using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class KeyUp : BaseEvent
    {

        [JsonProperty("payload")]
        public KeyPayload payload = new KeyPayload();

    }
}
