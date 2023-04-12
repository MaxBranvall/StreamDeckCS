using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.Helpers
{
    public class DialRotatePayload : BaseTouchPayload
    {
        [JsonProperty("ticks")]
        public int ticks { get; set; }

        [JsonProperty("pressed")]
        public bool pressed { get; set; }
    }
}
