using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StreamDeckCS.EventsReceived;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsSent
{
    internal class openUrl : BaseEvent
    {
        [JsonProperty("event")]
        string eventName = "openUrl";

        public Payload payload = new Payload();

    }

    class Payload
    {
        [JsonProperty("url")]
        string url = "https://www.google.com/";
    }
}
