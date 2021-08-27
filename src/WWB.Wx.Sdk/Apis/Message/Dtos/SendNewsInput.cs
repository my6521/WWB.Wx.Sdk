using Newtonsoft.Json;

namespace WWB.Wx.Sdk.Apis.Message
{
    public class SendNewsInput : SendInputBase
    {
        public SendNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }
        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        public class NewsInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}