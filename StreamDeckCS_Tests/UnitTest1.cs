using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WebSocketEnhanced;
using StreamDeckCS;
using System.Diagnostics.CodeAnalysis;

namespace StreamDeckCS_Tests
{
    [TestClass]
    public class UnitTest1
    {

        [ExcludeFromCodeCoverage]
        class TestClass : ICommManager
        {
            public event EventHandler<MessageEventArgs> MessageReceived;

            public Task ListenAsync()
            {
                throw new NotImplementedException();
            }

            public Task OpenSocketAsync()
            {
                throw new NotImplementedException();
            }

            public Task SendMessageAsync(string msg)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

            string port = "1234";
            string pluginUUID = "uuid";
            string registerEvent = "{'uuid': 'test', 'pluginEvent': 'ok'}";
            string info = "info";
            
            string[] args = { "-port", port, "-pluginUUID", pluginUUID, "-registerEvent", registerEvent, "-info", info };

            StreamdeckCore core = new StreamdeckCore(args, new TestClass());

            Assert.AreEqual(port, core.port);
            Assert.AreEqual(pluginUUID, core.pluginUUID);
            Assert.AreEqual(registerEvent, core.registerEvent);
            Assert.AreEqual(info, core.info);

        }
    }
}
