using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamDeckCS.EventsReceived
{
    public class SendToPlugin : BaseEvent
    {
        IPayload payload = new Payload();

        public class Payload : IPayload
        {

        }
    }
}
