using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS
{
    internal class RegisterEvent
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }

        public RegisterEvent(string ev, string uuid)
        {
            this.Event = ev;
            this.UUID = uuid;
        }
    }
}
