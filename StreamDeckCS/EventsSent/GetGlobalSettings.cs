using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.EventsSent
{
    public class GetGlobalSettings
    {
        [JsonProperty("event")]
        private string eventName = "setGlobalSettings";

        [JsonProperty("context")]
        private string context { get; set; }

        public GetGlobalSettings(string context)
        {
            this.context = context;
        }
    }
}
