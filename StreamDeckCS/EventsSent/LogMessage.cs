using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    class LogMessage
    {
        [JsonProperty("event")]
        string ev = "logMessage";

        [JsonProperty("payload")]
        internal Payload p = new Payload();

        internal class Payload
        {
            [JsonProperty("message")]
            public string message { get; set; }
        }

        public LogMessage(string msg)
        {
            this.p.message = msg;
        }

    }
}
