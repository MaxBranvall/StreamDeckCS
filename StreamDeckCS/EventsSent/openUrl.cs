﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StreamDeckCS.Events;

namespace StreamDeckCS.EventsSent
{
    internal class openUrl : BaseEvent
    {
        [JsonProperty("event")]
        string eventName = "openUrl";

        public Payload payload = new Payload();

    }

    class Payload : IPayload
    {
        [JsonProperty("url")]
        string url = "https://www.google.com/";
    }
}
