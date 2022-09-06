using System;
using System.Threading.Tasks;
using StreamDeckCS;

namespace SamplePlugin
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            StreamdeckCore core = new StreamdeckCore(args);
            await core.Start();
        }
    }
}
