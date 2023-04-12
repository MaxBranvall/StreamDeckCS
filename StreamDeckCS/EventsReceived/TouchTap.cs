using Newtonsoft.Json;
using StreamDeckCS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.EventsReceived
{
    public class TouchTap : BaseEvent
    {
        [JsonProperty("Payload")]
        public TouchTapPayload payload { get; set; }
    }
}
