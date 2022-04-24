using System;
using System.Threading;
using Newtonsoft.Json;
//using WebSocketSharp.NetCore;
//using System.Net.WebSockets;
using WebSocket4Net;
using System.Text;
using StreamDeckCS.Events;

namespace StreamDeckCS
{
    class StreamdeckCore
    {

        string port { get; set; }
        string pluginUUID { get; set; }
        string registerEvent { get; set; }
        string info { get; set; }

        PluginDetails details = new PluginDetails();
        Registration registration = new Registration();
        WebSocket ws;

        public StreamdeckCore(string port, string pluginUUID, string registerEvent, string info)
        {

            this.port = port;
            this.pluginUUID = pluginUUID;
            this.registerEvent = registerEvent;
            this.info = info;

            details.port = port;
            details.pluginUUID = pluginUUID;
            details.registerEvent = registerEvent;
            details.info = info;

            this.registration.UUID = pluginUUID;
            this.registration.pluginEvent = registerEvent;

            this._connectWebSocket();
        }

        private async void _connectWebSocket()
        {
            ws = new WebSocket("ws://localhost:" + this.port);
            ws.Opened += wsOpen;
            ws.MessageReceived += msgRecieved;
            ws.Open();
        }

        private void msgRecieved(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                if (JsonConvert.DeserializeObject<IEvent>(e.Message).eventName == "keyUp")
                {
                    ws.Send(JsonConvert.SerializeObject(new openUrl()));
                }
            } catch (Exception ex) { }
        }

        private void wsOpen(object sender, EventArgs e)
        {

            ws.Send(JsonConvert.SerializeObject(this.registration));
            LogMessage log = new LogMessage();

            log.p.message = "Testing from code!";

            ws.Send(JsonConvert.SerializeObject(log));

            ws.Send(JsonConvert.SerializeObject(new openUrl()));
        }

    }
}
