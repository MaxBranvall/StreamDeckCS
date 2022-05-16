using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsReceived
{
    public class BasePayload
    {
        [JsonProperty("settings")]
        public Settings settings = new Settings();

        [JsonProperty("coordinates")]
        public Coordinates coordinates = new Coordinates();

        [JsonProperty("state")]
        public int state { get; set; }

        [JsonProperty("userDesiredState")]
        public int userState { get; set; }

        [JsonProperty("isInMultiAction")]
        public bool multiAction { get; set; }
    }
}
