using Newtonsoft.Json;

namespace StreamDeckCS.EventsReceived
{
    public class DeviceDidDisconnect
    {
        [JsonProperty("event")]
        public string eventName { get; set; }
        public string device { get; set; }
    }
}
