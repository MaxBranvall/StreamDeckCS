using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class ShowAlert
    {
        [JsonProperty("event")]
        private string eventName = "showAlert";

        [JsonProperty("context")]
        private string context { get; set; }

        public ShowAlert(string context)
        {
            this.context = context;
        }
    }
}
