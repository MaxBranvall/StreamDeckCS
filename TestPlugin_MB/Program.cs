using System;
using System.Threading.Tasks;
using StreamDeckCS;
using Newtonsoft.Json;
using StreamDeckCS.Events;
using System.IO;

namespace TestPlugin_MB
{
    internal class Program
    {

        static StreamdeckCore core;

        static async Task Main(string[] args)
        {
            core = new StreamdeckCore(args);
            await core.Reg();

            string f = args[3];
            string x = args[5];

            File.WriteAllText("test.txt", f + " " + x);

            core.KeyUpEvent += Core_KeyUpEvent;

            await core.listenToSocket();
            
        }

        private static void Core_KeyUpEvent(object sender, KeyUpEvent e)
        {
            File.WriteAllText("keyup.txt", "key pressed");

            string p = "C:\\Users\\maxbr\\Documents\\Programming\\C#\\StreamDeckCS\\StreamDeckCS\\iracingProfile.png";

            byte[] arr = File.ReadAllBytes(p);
            string b64 = Convert.ToBase64String(arr);

            File.WriteAllText("image.txt", b64);

            //core.setTitle("Title from app", e.context);
            core.setImage("data:image/png;base64," + b64, e.context);
        }
    }
}
