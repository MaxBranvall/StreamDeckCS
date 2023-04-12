using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.Helpers
{
    public class BaseTouchPayload
    {
        [JsonProperty("settings")]
        public JObject settings { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates coordinates = new Coordinates();
    }
}
