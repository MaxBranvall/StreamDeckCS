﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class SendToPlugin : BaseEvent
    {
        [JsonProperty("payload")]
        public JObject payload { get; set; }
    }
}
