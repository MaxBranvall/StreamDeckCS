using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class ApplicationPayload
    {
        [JsonProperty("application")]
        public string application { get; set; }
    }
}
