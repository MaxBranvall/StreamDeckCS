using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class DeviceInfo
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type")]
        public DEVICE_TYPE type { get; set; }

        [JsonProperty("size")]
        public Coordinates size = new Coordinates();

    }
}
