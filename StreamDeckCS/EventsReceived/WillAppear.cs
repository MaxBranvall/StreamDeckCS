using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsReceived
{
    public class WillAppear : BaseEvent
    {
        public BasePayload payload { get; set; }
    }
}
