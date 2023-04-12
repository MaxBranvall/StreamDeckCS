using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.Helpers
{
    public class TouchTapPayload : BaseTouchPayload
    {
        [JsonProperty("TapPos")]
        public List<int> tapPos { get; set; }

        [JsonProperty("Hold")]
        public bool hold { get; set; }
    }
}
