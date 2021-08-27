using Newtonsoft.Json;

namespace WWB.Wx.Sdk.Apis.Menu
{
    public class GetMenuApiResult : ApiResultBase
    {
        [JsonProperty("menu")]
        public MenuInfo Menu { get; set; }
    }
}
