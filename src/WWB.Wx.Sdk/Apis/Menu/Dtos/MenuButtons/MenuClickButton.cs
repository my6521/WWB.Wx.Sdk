using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WWB.Wx.Sdk.Apis.Menu
{
    public class MenuClickButton : SubMenuButtonBase
    {
        public MenuClickButton()
        {
            Type = MenuButtonTypes.click;
        }

        /// <summary>
        /// 菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [Required]
        [StringLength(128)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
