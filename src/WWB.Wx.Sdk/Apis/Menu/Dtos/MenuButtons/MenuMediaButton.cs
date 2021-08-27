using System.ComponentModel.DataAnnotations;

namespace WWB.Wx.Sdk.Apis.Menu
{
    public class MenuMediaButton : SubMenuButtonBase
    {
        public MenuMediaButton()
        {
            Type = MenuButtonTypes.media_id;
        }

        /// <summary>
        /// 调用新增永久素材接口返回的合法media_id
        /// </summary>
        [Required]
        public string MediaId { get; set; }
    }
}
