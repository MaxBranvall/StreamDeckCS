using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace StreamDeckCS
{
    class LogMessage
    {
        [JsonProperty("event")]
        string ev = "logMessage";

        [JsonProperty("payload")]
        internal Payload p = new Payload();

        internal class Payload : IPayload
        {
            [JsonProperty("message")]
            public string message { get; set; }
        }

    }
}
