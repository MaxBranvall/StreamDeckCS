using Newtonsoft.Json;

namespace StreamDeckCS.Helpers
{
    public class BasePayloadWithMultiAction : BasePayload
    {

        [JsonProperty("isInMultiAction")]
        public bool isInmultiAction { get; set; }
    }
}
