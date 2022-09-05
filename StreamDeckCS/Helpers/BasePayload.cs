using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StreamDeckCS.EventsReceived;

namespace StreamDeckCS.Helpers
{
    public class BasePayload
    {
        [JsonProperty("settings")]
        public Settings settings = new Settings();

        [JsonProperty("coordinates")]
        public Coordinates coordinates = new Coordinates();

        [JsonProperty("state")]
        public int state { get; set; }

    }
}
