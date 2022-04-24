using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS
{
    internal class message
    {

        [JsonProperty("event")]
        public string ev { get; set; }

        [JsonProperty("action")]
        public string ac { get; set; }

        //[JsonProperty("context")]

        //[JsonProperty("device")]

    }
}
