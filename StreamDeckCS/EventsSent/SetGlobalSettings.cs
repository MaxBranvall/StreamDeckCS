using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.EventsSent
{
    public class SetGlobalSettings
    {

        [JsonProperty("event")]
        private string eventName = "setGlobalSettings";

        [JsonProperty("context")]
        private string context { get; set; }

        [JsonProperty("payload")]
        public JObject payload { get; set; }

        public SetGlobalSettings(string context, JObject payload)
        {
            this.context = context;
            this.payload = payload;
        }

    }
}
