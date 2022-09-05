using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class DidReceiveSettings : BaseEvent
    {

        [JsonProperty("payload")]
        public BasePayloadWithMultiAction payload = new BasePayloadWithMultiAction();          

    }
}
