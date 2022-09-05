using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class TitleParamPayload : BasePayload
    {

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("titleParameters")]
        public TitleParameters titleParameters = new TitleParameters();

    }
}
