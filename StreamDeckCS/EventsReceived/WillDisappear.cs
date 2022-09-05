using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class WillDisappear : BaseEvent
    {
        [JsonProperty("payload")]
        public BasePayloadWithMultiAction payload { get; set; }
    }
}
