﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.EventsReceived
{
    public class SendToPlugin : BaseEvent
    {
        public JObject payload { get; set; }
    }
}
