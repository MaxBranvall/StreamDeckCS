using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class ApplicationDidLaunch
    {

        [JsonProperty("event")]
        public string eventName { get; set; }

        [JsonProperty("payload")]
        public ApplicationPayload payload { get; set; }

    }
}
