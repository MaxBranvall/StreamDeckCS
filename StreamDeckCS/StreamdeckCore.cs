using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketEnhanced;
using StreamDeckCS.Helpers;
using StreamDeckCS.EventsSent;
using StreamDeckCS.EventsReceived;

namespace StreamDeckCS
{
    public class StreamdeckCore
    {

        public string port { get; set; }
        public string pluginUUID { get; set; }
        public string registerEvent { get; set; }
        public string info { get; set; }

        Registration registration = new Registration();
        ICommManager webSocket;

        public event EventHandler<KeyUp> KeyUpEvent;
        public event EventHandler<KeyDown> KeyDownEvent;
        public event EventHandler<PropertyInspectorDidAppear> PropertyInspectorAppearedEvent;
        public event EventHandler<WillAppear> WillAppearEvent;
        public event EventHandler<WillDisappear> WillDisappearEvent;
        public event EventHandler<SendToPlugin> SendToPluginEvent;
        public event EventHandler<DidReceiveSettings> DidReceiveSettingsEvent;
        public event EventHandler<DidReceiveGlobalSettings> DidReceiveGlobalSettingsEvent;
        public event EventHandler<TitleParametersDidChange> TitleParametersDidChangeEvent;
        public event EventHandler<DeviceDidConnect> DeviceDidConnectEvent;
        public event EventHandler<DeviceDidDisconnect> DeviceDidDisconnectEvent;
        public event EventHandler<ApplicationDidLaunch> ApplicationDidLaunchEvent;
        public event EventHandler<ApplicationDidTerminate> ApplicationDidTerminateEvent;
        public event EventHandler<SystemDidWakeUp> SystemDidWakeUpEvent;
        public event EventHandler<PropertyInspectorDidDisappear> PropertyInspectorDidDisappearEvent;

        public StreamdeckCore(string[] args)
        {

            setProperties(args);

            this.webSocket = new WebSocketEnhancedCore(this.port);
            this.webSocket.MessageReceived += WebSocket_MessageReceived;
            
        }

        public StreamdeckCore(string[] args, ICommManager socket)
        {
            setProperties(args);

            this.webSocket = socket;
            this.webSocket.MessageReceived += WebSocket_MessageReceived;
        }

        private void setProperties(string[] args)
        {
            parseArgs(args);

            this.registration.UUID = pluginUUID;
            this.registration.pluginEvent = registerEvent;
        }

        /// <summary>
        /// Opens communication with the Stream Deck application, registers your plugin, and begins listening for messages.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            await this.webSocket.OpenSocketAsync();
            await this.webSocket.SendMessageAsync(JsonConvert.SerializeObject(this.registration));
            this.LogMessage("Plugin registered!");
            this.LogMessage("I'm listening...");
            await this.webSocket.ListenAsync();
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

        public void setSettings(string context, JObject payload)
        {
            this._sendMessage(new SetSettings(context, payload));
        }

        public void getSettings(string context)
        {
            this._sendMessage(new GetSettings(context));
        }

        public void setGlobalSettings(string context, JObject payload)
        {
            this._sendMessage(new SetGlobalSettings(context, payload));
        }

        public void getGlobalSettings(string context)
        {
            this._sendMessage(new GetGlobalSettings(context));
        }

        public void openUrl(string url)
        {
            this._sendMessage(new OpenUrl(url));            
        }

        public void LogMessage(string msg)
        {
            this._sendMessage(new LogMessage(msg));
        }

        public void setTitle(string context, string title, TARGET target = TARGET.HARDWARE_AND_SOFTWARE, int state = 0)
        {
            this._sendMessage(new SetTitle(context, title, target, state));
        }

        public void setImage(string context, string imagePath, TARGET target = TARGET.HARDWARE_AND_SOFTWARE, int state = 0, bool svg = false)
        {
            this._sendMessage(new SetImage(context, imagePath, target, state, svg));
        }

        public void showAlert(string context)
        {
            this._sendMessage(new ShowAlert(context));
        }

        public void showOk(string context)
        {
            this._sendMessage(new ShowOk(context));
        }

        public void setState(string context, int state)
        {
            this._sendMessage(new SetState(context, state));
        }

        public void switchToProfile(string context, string device, string profileName)
        {
            this._sendMessage(new SwitchToProfile(context, device, profileName));
        }

        public void sendToPI(string context, string action, JObject payload)
        {
            this._sendMessage(new SendToPropertyInspector(context, action, payload));
        }

        private void _sendMessage(object msg)
        {
            this.webSocket.SendMessageAsync(JsonConvert.SerializeObject(msg));
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
                    case Constants.PI_DISAPPEARED:
                        OnPropertyInspectorDisappearedEvent(JsonConvert.DeserializeObject<PropertyInspectorDidDisappear>(e.message));
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
                    case Constants.DID_RECEIVE_GLOBAL_SETTINGS:
                        OnDidReceiveGlobalSettings(JsonConvert.DeserializeObject<DidReceiveGlobalSettings>(e.message));
                        break;
                    case Constants.TITLE_PARAMETERS_DID_CHANGE:
                        OnTitleParametersDidChange(JsonConvert.DeserializeObject<TitleParametersDidChange>(e.message));
                        break;
                    case Constants.DEVICE_DID_CONNECT:
                        OnDeviceDidConnect(JsonConvert.DeserializeObject<DeviceDidConnect>(e.message));
                        break;
                    case Constants.DEVICE_DID_DISCONNECT:
                        OnDeviceDidDisconnect(JsonConvert.DeserializeObject<DeviceDidDisconnect>(e.message));
                        break;
                    case Constants.APPLICATION_DID_LAUNCH:
                        OnApplicationDidLaunch(JsonConvert.DeserializeObject<ApplicationDidLaunch>(e.message));
                        break;
                    case Constants.APPLICATION_DID_TERMINATE:
                        OnApplicationDidTerminate(JsonConvert.DeserializeObject<ApplicationDidTerminate>(e.message));
                        break;
                    case Constants.SYSTEM_DID_WAKE_UP:
                        OnSystemDidWakeUp(JsonConvert.DeserializeObject<SystemDidWakeUp>(e.message));
                        break;

                    default:
                        break;
                }
            } catch(Exception ex)
            {
                this.LogMessage("Caught error: " + ex.ToString());
            }


        }

        private void OnSystemDidWakeUp(SystemDidWakeUp e)
        {
            EventHandler<SystemDidWakeUp> handler = SystemDidWakeUpEvent;

            if (handler != null)
            {
                this.LogMessage("systemDidWakeUp fired");
                handler?.Invoke(this, e);
            }
        }

        private void OnApplicationDidTerminate(ApplicationDidTerminate e)
        {
            EventHandler<ApplicationDidTerminate> handler = ApplicationDidTerminateEvent;

            if (handler != null)
            {
                this.LogMessage("applicationDidTerminate fired");
                handler?.Invoke(this, e);
            }
        }

        private void OnApplicationDidLaunch(ApplicationDidLaunch e)
        {
            EventHandler<ApplicationDidLaunch> handler = ApplicationDidLaunchEvent;

            if (handler != null)
            {
                this.LogMessage("applicationDidLaunch fired");
                handler?.Invoke(this, e);
            }
        }

        private void OnDeviceDidDisconnect(DeviceDidDisconnect e)
        {
            EventHandler<DeviceDidDisconnect> handler = DeviceDidDisconnectEvent;

            if (handler != null)
            {
                this.LogMessage("deviceDidDisconnect fired");
                handler?.Invoke(this, e);
            }
        }

        private void OnDeviceDidConnect(DeviceDidConnect e)
        {
            EventHandler<DeviceDidConnect> handler = DeviceDidConnectEvent;

            if (handler != null)
            {
                this.LogMessage("deviceDidConnect fired");
                handler?.Invoke(this, e);
            }
        }

        private void OnTitleParametersDidChange(TitleParametersDidChange e)
        {
            EventHandler<TitleParametersDidChange> handler = TitleParametersDidChangeEvent;

            if (handler != null)
            {
                this.LogMessage("titleParametersDidChange fired");
                handler?.Invoke(this, e);
            }
        }

        private void OnPropertyInspectorDisappearedEvent(PropertyInspectorDidDisappear e)
        {
            EventHandler<PropertyInspectorDidDisappear> handler = PropertyInspectorDidDisappearEvent;

            if (handler != null)
            {
                this.LogMessage("propertyInspectorDisappeared fired");
                handler?.Invoke(this, e);
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

        private void OnDidReceiveGlobalSettings(DidReceiveGlobalSettings e)
        {
            EventHandler<DidReceiveGlobalSettings> handler = DidReceiveGlobalSettingsEvent;

            if (handler != null)
            {
                this.LogMessage("didReceiveGlobalSettings fired");
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
