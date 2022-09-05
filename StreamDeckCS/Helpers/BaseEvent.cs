using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class BaseEvent
    {        
        [JsonProperty("action")]
        public string action { get; set; }

        [JsonProperty("event")]
        public string eventName { get; set; }

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("device")]
        public string device { get; set; }
    }
}
