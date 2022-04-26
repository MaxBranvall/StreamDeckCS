using System;
using System.Threading;
using Newtonsoft.Json;
using System.Text;
using WebSocketEnhanced;
using StreamDeckCS.Events;
using System.Threading.Tasks;
using System.IO;

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

        public event EventHandler<KeyUpEvent> KeyUpEvent;

        private const string KEY_UP = "keyUp";

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

        public async Task Reg()
        {
            await this.webSocket.OpenSocket();
            await this.webSocket.SendMessage(JsonConvert.SerializeObject(this.registration));
            File.WriteAllText("register.txt", "registered");
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

        public async Task listenToSocket()
        {
            File.WriteAllText("listen.txt", "registered");
            await this.webSocket.Listen();
        }

        public void setTitle(string title, string context)
        {
            SetTitle t = new SetTitle();
            t.context = context;
            t.p.title = title;

            this.webSocket.SendMessage(JsonConvert.SerializeObject(t));
        }

        public void setImage(string base64Image, string context)
        {
            SetImage setImage = new SetImage();
            setImage.p.image = base64Image;
            setImage.context = context;

            this.webSocket.SendMessage(JsonConvert.SerializeObject(setImage));
        }

        private void WebSocket_MessageReceived(object sender, MessageEventArgs e)
        {
            var msg = JsonConvert.DeserializeObject<Event>(e.message);

            switch (msg.eventName)
            {
                case KEY_UP:
                    File.WriteAllText("gotkey.txt", "registered");
                    OnRaiseKeyUpEvent(JsonConvert.DeserializeObject<KeyUpEvent>(e.message));
                    break;
                default:
                    break;
            }
        }

        protected virtual void OnRaiseKeyUpEvent(KeyUpEvent e)
        {
            EventHandler<KeyUpEvent> keyUpCopy = KeyUpEvent;

            if (keyUpCopy != null)
            {
                LogMessage l = new LogMessage();
                l.p.message = "key up branflake";
                this.webSocket.SendMessage(JsonConvert.SerializeObject(l));
                keyUpCopy?.Invoke(this, e);
            }

        }

    }
}
