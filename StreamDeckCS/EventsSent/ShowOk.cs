using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class ShowOk
    {
        [JsonProperty("event")]
        private string eventName = "showOk";

        [JsonProperty("context")]
        private string context { get; set; }

        public ShowOk(string context)
        {
            this.context = context;
        }
    }
}
