using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    internal class SendToPropertyInspector
    {
        [JsonProperty("action")]
        string action { get; set; }

        [JsonProperty("event")]
        string ev = "sendToPropertyInspector";

        [JsonProperty("context")]
        string context { get; set; }

        [JsonProperty("payload")]
        public IPayload payload { get; set; }

        public SendToPropertyInspector(IPayload payload, string action, string context)
        {
            this.action = action;
            this.context = context;
            this.payload = payload;
        }

    }
}
