using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.EventsSent
{
    public class SetSettings
    {

        [JsonProperty("event")]
        private string ev = "setSettings";

        [JsonProperty("context")]
        public string context { get; private set; }

        [JsonProperty("payload")]
        public JObject payload { get; set; }

        public SetSettings(string context, JObject payload)
        {
            this.context = context;
            this.payload = payload;
        }

    }
}
