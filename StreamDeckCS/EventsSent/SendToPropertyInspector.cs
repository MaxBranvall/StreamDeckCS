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
        [JsonProperty("event")]
        string eventName = "sendToPropertyInspector";

        [JsonProperty("action")]
        string action { get; set; }

        [JsonProperty("context")]
        string context { get; set; }

        [JsonProperty("payload")]
        public JObject payload { get; set; }

        public SendToPropertyInspector(string context, string action, JObject payload)
        {
            this.action = action;
            this.context = context;
            this.payload = payload;
        }

    }
}
