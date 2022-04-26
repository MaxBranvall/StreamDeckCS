using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.Events
{
    public class KeyUpEvent
    {

        [JsonProperty("action")]
        public string action { get; set; }

        [JsonProperty("event")]
        public string eventName { get; set; }

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("device")]
        public string device { get; set; }

        [JsonProperty("payload")]
        public Payload p = new Payload();

    }

    public class Payload
    {
        [JsonProperty("settings")]
        public Settings settings = new Settings();

        [JsonProperty("coordinates")]
        public Coords coords = new Coords();

        [JsonProperty("state")]
        public int state { get; set; }

        [JsonProperty("userDesiredState")]
        public int userState { get; set; }

        [JsonProperty("isInMultiAction")]
        public bool multiAction { get; set; }
    }

    public class Coords
    {
        [JsonProperty("column")]
        public int column { get; set; }

        [JsonProperty("row")]
        public int row { get; set; }
    }

    public class Settings
    {

    }
}
