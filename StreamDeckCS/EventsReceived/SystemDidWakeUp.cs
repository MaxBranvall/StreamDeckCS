using Newtonsoft.Json;

namespace StreamDeckCS.EventsReceived
{
    public class SystemDidWakeUp
    {
        [JsonProperty("event")]
        public string eventName { get; set; }
    }
}
