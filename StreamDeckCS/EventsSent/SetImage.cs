using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using StreamDeckCS.Helpers;

namespace StreamDeckCS.EventsSent
{
    internal class SetImage
    {
        [JsonProperty("event")]
        public string eventName = "setImage";

        [JsonProperty("context")]
        public string context { get; set; }

        [JsonProperty("payload")]
        public SetImagePayload payload = new SetImagePayload();

        public SetImage(string context, string imagePath, TARGET target, int state, bool svg)
        {
            this.context = context;
            this.payload.image = encodeImage(imagePath, svg);
            this.payload.target = target;
            this.payload.state = state;
        }

        private string encodeImage(string imagePath, bool svg)
        {
            string encodedImage;
            string imageType;

            if (svg)
            {
                encodedImage = $"data:image/svg+xml;charset=utf8,{Encoding.UTF8.GetString(File.ReadAllBytes(imagePath))}";
                return encodedImage;
            }

            // split string and grab file extension at end of array
            string[] tmp = imagePath.Split('.');
            imageType = tmp[tmp.Length - 1];

            encodedImage = $"data:image/{imageType};base64,{Convert.ToBase64String(File.ReadAllBytes(imagePath))}";

            return encodedImage;

        }

    }

    class SetImagePayload
    {
        [JsonProperty("image")]
        internal string image { get; set; }

        [JsonProperty("target")]
        internal TARGET target { get; set; }

        [JsonProperty("state")]
        internal int state { get; set; }
    }
}
