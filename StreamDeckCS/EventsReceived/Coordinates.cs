using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsReceived
{
    public class Coordinates
    {
        [JsonProperty("column")]
        public int column { get; set; }

        [JsonProperty("row")]
        public int row { get; set; }
    }
}
