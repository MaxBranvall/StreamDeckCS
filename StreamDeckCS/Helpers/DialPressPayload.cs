using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.Helpers
{
    public class DialPressPayload : BaseTouchPayload
    {
        [JsonProperty("Pressed")]
        public bool pressed { get; set; }
    }
}
