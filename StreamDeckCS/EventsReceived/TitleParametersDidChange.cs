using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class TitleParametersDidChange : BaseEvent
    {

        [JsonProperty("payload")]
        public TitleParamPayload payload = new TitleParamPayload();

    }
}
