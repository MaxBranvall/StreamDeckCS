using System;
using System.Threading.Tasks;
using StreamDeckCS;
using Newtonsoft.Json;
using StreamDeckCS.Events;
using System.IO;
using StreamDeckCS.EventsReceived;

namespace TestPlugin_MB
{
    internal class Program
    {

        static StreamdeckCore core;

        static async Task Main(string[] args)
        {
            core = new StreamdeckCore(args);

            core.KeyUpEvent += Core_KeyUpEvent;

            await core.Start();            
            
        }

        private static void Core_KeyUpEvent(object sender, KeyUp e)
        {
            string p = "C:\\Users\\maxbr\\Documents\\Programming\\C#\\StreamDeckCS\\StreamDeckCS\\iracingProfile.png";

            core.setImage(p, e.context);
            core.setTitle("Test title", e.context);
        }
    }
}
