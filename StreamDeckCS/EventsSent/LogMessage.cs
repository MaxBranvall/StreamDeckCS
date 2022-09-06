using Newtonsoft.Json;

namespace StreamDeckCS.EventsSent
{
    public class LogMessage
    {
        [JsonProperty("event")]
        string eventName = "logMessage";

        [JsonProperty("payload")]
        internal LogMessagePayload payload = new LogMessagePayload();

        public LogMessage(string message)
        {
            this.payload.message = message;
        }

    }

    class LogMessagePayload
    {
        [JsonProperty("message")]
        internal string message { get; set; }
    }
}
