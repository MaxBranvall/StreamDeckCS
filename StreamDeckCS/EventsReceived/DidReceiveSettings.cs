using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StreamDeckCS.EventsReceived
{
    public class DidReceiveSettings : BaseEvent
    {
        //public BasePayload payload = new BasePayload();

        [JsonProperty("payload")]
        public payload payload2 = new payload();


        public class payload
        {
            [JsonProperty("coordinates")]
            public Coordinates coordinates = new Coordinates();

            [JsonProperty("state")]
            public int state { get; set; }

            [JsonProperty("userDesiredState")]
            public int userState { get; set; }

            [JsonProperty("isInMultiAction")]
            public bool multiAction { get; set; }

            [JsonProperty("settings")]
            public JObject general { get; set; }
    }
    }
}
