using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.Events
{
    internal class SetImage
    {
        [JsonProperty("event")]
        public string eventName = "setImage";

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("payload")]
        public PayloadTitle2 p = new PayloadTitle2();

        public SetImage(string b64Encoded, string context)
        {
            p.image = b64Encoded;
            this.context = context;
        }

    }

    public class PayloadTitle2
    {
        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("target")]
        public int target { get; set; }

        [JsonProperty("state")]
        public int state { get; set; }
    }
}
