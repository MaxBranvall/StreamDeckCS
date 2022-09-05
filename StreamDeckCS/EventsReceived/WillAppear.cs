using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class WillAppear : BaseEvent
    {
        [JsonProperty("payload")]
        public BasePayloadWithMultiAction payload { get; set; }
    }
}
