using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class SetState
    {
        [JsonProperty("event")]
        private string eventName = "setState";

        [JsonProperty("context")]
        private string context { get; set; }

        [JsonProperty("payload")]
        private SetStatePayload payload = new SetStatePayload();

        public SetState(string context, int state)
        {
            this.context = context;
            this.payload.state = state;
        }

    }

    class SetStatePayload
    {
        [JsonProperty("state")]
        internal int state { get; set; }
    }
}
