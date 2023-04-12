using Newtonsoft.Json;
using StreamDeckCS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.EventsReceived
{
    public class DialPress : BaseEvent
    {
        [JsonProperty("payload")]
        public DialPressPayload payload { get; set; }
    }
}
