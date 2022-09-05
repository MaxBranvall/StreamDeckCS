using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class KeyPayload : BasePayloadWithMultiAction
    {
        [JsonProperty("userDesiredState")]
        public int userDesiredState { get; set; }
    }
}
