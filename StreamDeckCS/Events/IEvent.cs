using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.Events
{
    internal class IEvent
    {        
        internal string eventName { get; set; }

        [JsonProperty("payload")]
        IPayload payload { get; set; }
    }
}
