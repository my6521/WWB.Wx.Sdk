using Newtonsoft.Json;

namespace WWB.Wx.Sdk.Apis.User.Dtos
{
    public class GetIdListInput
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }
}