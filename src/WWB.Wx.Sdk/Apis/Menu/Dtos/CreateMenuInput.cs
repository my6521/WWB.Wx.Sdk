using Newtonsoft.Json;
using System.Collections.Generic;

namespace WWB.Wx.Sdk.Apis.Menu
{
    public class CreateMenuInput
    {
        [JsonProperty("button")]
        public List<MenuButtonBase> Button { get; set; }
    }
}
