using System;

namespace StreamDeckCS
{
    class Program
    {

        static string port = "-port";
        static string pluginUUID = "-pluginUUID";
        static string registerEvent = "-registerEvent";
        static string info = "-info";

        static void Main(string[] args)
        {
            parseArgs(args);

            StreamdeckCore streamdeckCore = new StreamdeckCore(port, pluginUUID, registerEvent, info);

            while (true) { }

        }

        static void parseArgs(string[] args)
        {

            for (int i = 0; i < args.Length; i += 2)
            {

                switch(args[i])
                {
                    case "-port":
                        port = args[i + 1];
                        break;

                    case "-pluginUUID":
                        pluginUUID = args[i + 1];
                        break;

                    case "-registerEvent":
                        registerEvent = args[i + 1];
                        break;

                    case "-info":
                        info = args[i + 1];
                        break;

                    default:
                        Console.WriteLine("Unknown argument..");
                        Console.WriteLine(args[i]);
                        break;
                }

            }

        }
    }
}
