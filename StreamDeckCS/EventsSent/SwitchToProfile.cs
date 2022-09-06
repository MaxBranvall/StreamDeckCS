using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class SwitchToProfile
    {

        [JsonProperty("event")]
        private string eventName = "switchToProfile";

        [JsonProperty("context")]
        private string context { get; set; }

        [JsonProperty("device")]
        private string device { get; set; }

        [JsonProperty("payload")]
        private ProfilePayload payload = new ProfilePayload();

        public SwitchToProfile(string context, string device, string profileName)
        {
            this.context = context;
            this.device = device;
            this.payload.profile = profileName;
        }

    }

    class ProfilePayload
    {
        [JsonProperty("profile")]
        internal string profile { get; set; }
    }
}
