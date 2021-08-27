using Newtonsoft.Json;

namespace WWB.Wx.Sdk.Apis.Message
{
    public class SendTemplateMessageApiResult : ApiResultBase
    {
        [JsonProperty("msgid")]
        public string MessageId { get; set; }
    }
}