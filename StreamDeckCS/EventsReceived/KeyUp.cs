using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.EventsReceived
{
    public class KeyUp : BaseEvent
    {

        [JsonProperty("payload")]
        public Payload p = new Payload();

        public class Payload
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

    public class Settings
    {
        public dynamic general { get; set; }
    }
}
