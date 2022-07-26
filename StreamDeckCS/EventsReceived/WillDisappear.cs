using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS.EventsReceived
{
    public class WillDisappear : BaseEvent
    {
        public BasePayload payload { get; set; }
    }
}
