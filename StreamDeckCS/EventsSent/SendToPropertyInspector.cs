using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public JObject payload { get; set; }

        public SendToPropertyInspector(JObject payload, string action, string context)
        {
            this.action = action;
            this.context = context;
            this.payload = payload;
        }

    }
}
