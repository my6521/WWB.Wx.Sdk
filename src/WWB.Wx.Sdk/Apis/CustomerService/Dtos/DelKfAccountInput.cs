using Newtonsoft.Json;

namespace WWB.Wx.Sdk.Apis.CustomerService
{
    public class DelKfAccountInput
    {
        [JsonProperty("kf_account")]
        public string Account { get; set; }
    }
}