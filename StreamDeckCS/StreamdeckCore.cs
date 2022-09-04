using System;
using System.Threading;
using Newtonsoft.Json;
using System.Text;
using WebSocketEnhanced;
using System.Threading.Tasks;
using System.IO;
using StreamDeckCS.EventsSent;
using StreamDeckCS.EventsReceived;
using Newtonsoft.Json.Linq;

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
        public event EventHandler<WillAppear> WillAppearEvent;
        public event EventHandler<WillDisappear> WillDisappearEvent;
        public event EventHandler<SendToPlugin> SendToPluginEvent;
        public event EventHandler<DidReceiveSettings> DidReceiveSettingsEvent;

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

        public void sendToPI(JObject payload, string context)
        {
            var msg = new SendToPropertyInspector(payload, pluginUUID, context);

            this._sendMessage(msg);
        }

        public void getSettings(string context)
        {
            this._sendMessage(new GetSettings(context));
        }

        public void setSettings(string context, JObject payload)
        {
            this._sendMessage(new SetSettings(context, payload));
        }

        private void _sendMessage(object msg)
        {
            this.webSocket.SendMessage(JsonConvert.SerializeObject(msg));
        }

        private void WebSocket_MessageReceived(object sender, MessageEventArgs e)
        {

            try
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
                    case Constants.WILL_APPEAR:
                        OnWillAppearEvent(JsonConvert.DeserializeObject<WillAppear>(e.message));
                        break;
                    case Constants.WILL_DISAPPEAR:
                        OnWillDisappearEvent(JsonConvert.DeserializeObject<WillDisappear>(e.message));
                        break;
                    case Constants.SEND_TO_PLUGIN:
                        OnSendToPluginEvent(JsonConvert.DeserializeObject<SendToPlugin>(e.message));
                        break;
                    case Constants.DID_RECEIVE_SETTINGS:
                        OnDidReceiveSettings(JsonConvert.DeserializeObject<DidReceiveSettings>(e.message));
                        break;

                    default:
                        break;
                }
            } catch(Exception ex)
            {
                this.LogMessage("Caught error: " + ex.ToString());
            }


        }

        private void OnDidReceiveSettings(DidReceiveSettings e)
        {
            EventHandler<DidReceiveSettings> handler = DidReceiveSettingsEvent;

            if (handler != null)
            {
                this.LogMessage("didReceiveSettings fired");
                handler?.Invoke(this, e);
            }
        }

        protected virtual void OnSendToPluginEvent(SendToPlugin e)
        {
            EventHandler<SendToPlugin> handler = SendToPluginEvent;

            if (handler != null)
            {
                this.LogMessage("SendToPlugin Fired");
                handler?.Invoke(this, e);
            }

        }

        protected virtual void OnWillAppearEvent(WillAppear e)
        {
            EventHandler<WillAppear> handler = WillAppearEvent;

            if (handler != null)
            {
                this.LogMessage("WillAppear Fired");
                handler?.Invoke(this, e);
            }

        }

        protected virtual void OnWillDisappearEvent(WillDisappear e)
        {
            EventHandler<WillDisappear> handler = WillDisappearEvent;

            if (handler != null)
            {
                this.LogMessage("WillDisappear Fired");
                handler?.Invoke(this, e);
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
