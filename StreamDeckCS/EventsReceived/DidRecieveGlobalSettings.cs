using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class DidReceiveGlobalSettings
    {
        [JsonProperty("event")]
        public string eventName { get; set; }

        [JsonProperty("payload")]
        public GlobalSettingsPayload payload = new GlobalSettingsPayload();
    }
}
