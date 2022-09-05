using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class Coordinates
    {
        [JsonProperty("column")]
        public int column { get; set; }

        [JsonProperty("row")]
        public int row { get; set; }
    }
}
