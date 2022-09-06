using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsSent
{
    public class SetTitle
    {
        [JsonProperty("event")]
        public string eventName = "setTitle";

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("payload")]
        SetTitlePayload payload = new SetTitlePayload();

        public SetTitle(string context, string title, TARGET target = TARGET.HARDWARE_AND_SOFTWARE, int state = 0)
        {
            this.context = context;
            this.payload.title = title;
            this.payload.target = target;
            this.payload.state = state;
        }

    }

    class SetTitlePayload
    {
        [JsonProperty("title")]
        internal string title { get; set; }

        [JsonProperty("target")]
        internal TARGET target { get; set; }

        [JsonProperty("state")]
        internal int state { get; set; }
    }

}
