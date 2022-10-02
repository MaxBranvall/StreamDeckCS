using System;
using System.Threading.Tasks;
using StreamDeckCS;
using StreamDeckCS.EventsReceived;

namespace SamplePlugin
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SamplePlugin plugin = new SamplePlugin(args);
            await plugin.startPlugin();
        }
    }

    public class SamplePlugin
    {

        StreamdeckCore core;

        public SamplePlugin(string[] args)
        {
            core = new StreamdeckCore(args);

            core.KeyDownEvent += Core_KeyDownEvent;
        }

        private void Core_KeyDownEvent(object sender, KeyDown e)
        {
            throw new NotImplementedException();
        }

        public async Task startPlugin()
        {
            await core.Start();
        }

    }
}
