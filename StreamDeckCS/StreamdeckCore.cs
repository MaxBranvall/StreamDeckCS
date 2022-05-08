using System;
using System.Threading;
using Newtonsoft.Json;
using System.Text;
using WebSocketEnhanced;
using StreamDeckCS.Events;
using System.Threading.Tasks;
using System.IO;
using StreamDeckCS.EventsSent;
using StreamDeckCS.EventsReceived;

namespace StreamDeckCS
{
    public class StreamdeckCore
    {

        string port { get; set; }
        string pluginUUID { get; set; }
        string registerEvent { get; set; }
        string info { get; set; }

        PluginDetails details = new PluginDetails();
        Registration registration = new Registration();
        WebSocketEnhancedCore webSocket;

        public event EventHandler<KeyUp> KeyUpEvent;
        public event EventHandler<KeyDown> KeyDownEvent;
        public event EventHandler<PropertyInspectorDidAppear> PropertyInspectorAppearedEvent;

        public StreamdeckCore(string[] args)
        {

            parseArgs(args);

            details.port = port;
            details.pluginUUID = pluginUUID;
            details.registerEvent = registerEvent;
            details.info = info;

            this.registration.UUID = pluginUUID;
            this.registration.pluginEvent = registerEvent;

            this.webSocket = new WebSocketEnhancedCore(this.port);
            this.webSocket.MessageReceived += WebSocket_MessageReceived;
            
        }

        /// <summary>
        /// Opens communication with the Stream Deck application, registers your plugin, and begins listening for messages.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            await this.webSocket.OpenSocket();
            await this.webSocket.SendMessage(JsonConvert.SerializeObject(this.registration));
            this.LogMessage("Plugin registered!");
            this.LogMessage("I'm listening...");
            await this.webSocket.Listen();
        }

        private void parseArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i += 2)
            {

                switch (args[i])
                {
                    case "-port":
                        this.port = args[i + 1];
                        break;

                    case "-pluginUUID":
                        this.pluginUUID = args[i + 1];
                        break;

                    case "-registerEvent":
                        this.registerEvent = args[i + 1];
                        break;

                    case "-info":
                        this.info = args[i + 1];
                        break;

                    default:
                        break;
                }

            }
        }

        public void LogMessage(string msg)
        {
            this._sendMessage(new LogMessage(msg));
        }

        public void setTitle(string title, string context)
        {
            this._sendMessage(new SetTitle(title, context));
        }

        public void setImage(string imagePath, string context)
        {
            // reads image into a byte array and converts it to a base64 encoded string. Metadata is manually appended
            string b64Encoded = $"data:image/png;base64,{Convert.ToBase64String(File.ReadAllBytes(imagePath))}";

            var setImage = new SetImage(b64Encoded, context);

            this._sendMessage(setImage);
        }

        public void sendToPI(IPayload payload, string context)
        {
            var msg = new SendToPropertyInspector(payload, pluginUUID, context);

            this._sendMessage(msg);
        }

        private void _sendMessage(object msg)
        {
            this.webSocket.SendMessage(JsonConvert.SerializeObject(msg));
        }

        private void WebSocket_MessageReceived(object sender, MessageEventArgs e)
        {
            var msg = JsonConvert.DeserializeObject<BaseEvent>(e.message);

            switch (msg.eventName)
            {
                case Constants.KEY_UP:
                    OnRaiseKeyUpEvent(JsonConvert.DeserializeObject<KeyUp>(e.message));
                    break;
                case Constants.KEY_DOWN:
                    OnRaiseKeyDownEvent(JsonConvert.DeserializeObject<KeyDown>(e.message));
                    break;
                case Constants.PI_APPEARED:
                    OnPropertyInspectorAppearedEvent(JsonConvert.DeserializeObject<PropertyInspectorDidAppear>(e.message));
                    break;
                default:
                    break;
            }
        }

        protected virtual void OnPropertyInspectorAppearedEvent(PropertyInspectorDidAppear e)
        {
            EventHandler<PropertyInspectorDidAppear> handler = PropertyInspectorAppearedEvent;

            if (handler != null)
            {
                this.LogMessage("PI Appeared");
                handler?.Invoke(this, e);
            }
        }

        protected virtual void OnRaiseKeyUpEvent(KeyUp e)
        {
            EventHandler<KeyUp> keyUpCopy = KeyUpEvent;

            if (keyUpCopy != null)
            {
                this.LogMessage("Got key up event");
                keyUpCopy?.Invoke(this, e);
            }

        }

        protected virtual void OnRaiseKeyDownEvent(KeyDown e)
        {
            EventHandler<KeyDown> keyDownCopy = KeyDownEvent;

            if (keyDownCopy != null)
            {
                this.LogMessage("Got key down event");
                keyDownCopy?.Invoke(this, e);
            }
        }

    }
}
