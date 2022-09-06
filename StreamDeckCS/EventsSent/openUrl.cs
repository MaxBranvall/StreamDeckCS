using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class OpenUrl
    {
        [JsonProperty("event")]
        private readonly string eventName = "openUrl";

        [JsonProperty("payload")]
        private UrlPayload payload = new UrlPayload();

        public OpenUrl(string url)
        {
            this.payload.url = url;
        }

    }

    class UrlPayload
    {
        [JsonProperty("url")]
        internal string url = "https://www.google.com/";
    }
}
