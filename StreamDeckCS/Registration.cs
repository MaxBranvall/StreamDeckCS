using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS
{
    class Registration
    {

        [JsonProperty("event")]
        public string pluginEvent { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }

    }
}
