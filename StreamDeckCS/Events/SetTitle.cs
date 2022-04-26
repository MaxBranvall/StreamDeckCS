using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.Events
{
    internal class SetTitle
    {
        [JsonProperty("event")]
        public string eventName = "setTitle";

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("payload")]
        public PayloadTitle p = new PayloadTitle();

    }

    public class PayloadTitle
    {
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("target")]
        public int target { get; set; }

        [JsonProperty("state")]
        public int state { get; set; }
    }
}
