using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.Helpers
{
    public class GlobalSettingsPayload
    {

        [JsonProperty("settings")]
        public JObject settings { get; set; }

    }
}
