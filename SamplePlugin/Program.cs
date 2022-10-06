using System;
using System.Timers;
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
            await plugin.startPluginAsync();
        }
    }

    public class SamplePlugin
    {

        StreamdeckCore core;
        Timer timer;

        // fields
        private int numPressed = 0;
        private int timerDuration = 2000;
        private string context = null;

        public SamplePlugin(string[] args)
        {
            core = new StreamdeckCore(args);
            timer = new Timer(timerDuration);

            // subscribe to events
            timer.Elapsed += Timer_Elapsed;
            core.KeyUpEvent += Core_KeyUpEvent;
            core.KeyDownEvent += Core_KeyDownEvent;
            core.WillAppearEvent += Core_WillAppearEvent;

            // enable our timer so we can detect when button is held for timerDuration
            timer.Enabled = true;

        }

        // raises when button is held for timerDuration (2000 ms i.e 2 seconds), resets counter
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            numPressed = 0;
            core.setTitle(this.context, "0");
        }
        
        // when we begin pressing a key, store context for use by timer_elapsed, and start the timer
        private void Core_KeyDownEvent(object sender, KeyDown e)
        {
            context = e.context;
            timer.Start();
        }

        // when we release key, stop timer and set title of the key to next num in fibonacci sequence
        private void Core_KeyUpEvent(object sender, KeyUp e)
        {
            timer.Stop();
            core.setTitle(e.context, fibonacci(++numPressed).ToString());
        }

        // when the key appears on the stream deck, set title to "Fib"
        private void Core_WillAppearEvent(object sender, WillAppear e)
        {
            core.setTitle(e.context, "Fib");
        }

        // starts the plugin
        public async Task startPluginAsync()
        {
            await core.Start();
        }

        private double fibonacci(int n)
        {

            if (n < 1)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return fibonacci(n - 1) + fibonacci(n - 2);

        }

    }
}
