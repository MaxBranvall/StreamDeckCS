using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsReceived
{
    public class KeyDown : BaseEvent
    {

        [JsonProperty("payload")]
        public KeyPayload payload = new KeyPayload();

    }
}
