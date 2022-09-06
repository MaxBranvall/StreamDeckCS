using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class GetSettings
    {

        [JsonProperty("event")]
        private string eventName = "getSettings";

        [JsonProperty("context")]
        public string context { get; private set; }

        public GetSettings(string context)
        {
            this.context = context;
        }

    }
}
