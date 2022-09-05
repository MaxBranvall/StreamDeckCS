using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class DeviceDidConnect
    {

        [JsonProperty("event")]
        public string eventName { get; set; }

        [JsonProperty("device")]
        public string device { get; set; }

        [JsonProperty("deviceInfo")]
        public DeviceInfo deviceInfo = new DeviceInfo();

    }
}
