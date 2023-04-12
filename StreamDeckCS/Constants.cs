using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDeckCS
{
    public class Constants
    {

        public const string KEY_UP = "keyUp";
        public const string KEY_DOWN = "keyDown";

        public const string PI_APPEARED = "propertyInspectorDidAppear";
        public const string PI_DISAPPEARED = "propertyInspectorDidDisappear";
        public const string WILL_APPEAR = "willAppear";
        public const string WILL_DISAPPEAR = "willDisappear";

        public const string SEND_TO_PLUGIN = "sendToPlugin";

        public const string DID_RECEIVE_SETTINGS = "didReceiveSettings";
        public const string DID_RECEIVE_GLOBAL_SETTINGS = "didReceiveGlobalSettings";

        public const string TITLE_PARAMETERS_DID_CHANGE = "titleParametersDidChange";

        public const string DEVICE_DID_CONNECT = "deviceDidConnect";
        public const string DEVICE_DID_DISCONNECT = "deviceDidDisconnect";

        public const string APPLICATION_DID_LAUNCH = "applicationDidLaunch";
        public const string APPLICATION_DID_TERMINATE = "applicationDidTerminate";

        public const string SYSTEM_DID_WAKE_UP = "systemDidWakeUp";

        public const string TOUCH_TAP = "touchTap";
        public const string DIAL_PRESS = "dialPress";
        public const string DIAL_ROTATE = "dialRotate";
    }
}
