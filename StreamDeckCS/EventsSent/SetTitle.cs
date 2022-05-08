using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    internal class SetTitle
    {
        [JsonProperty("event")]
        public string eventName = "setTitle";

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("payload")]
        Payload payload = new Payload();

        private class Payload
        {
            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("target")]
            public int target { get; set; }

            [JsonProperty("state")]
            public int state { get; set; }
        }

        public SetTitle(string title, string context)
        {
            this.payload.title = title;
            this.context = context;
        }

    }


}
