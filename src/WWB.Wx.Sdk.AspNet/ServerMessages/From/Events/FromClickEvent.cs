namespace WWB.Wx.Sdk.AspNet.ServerMessages.From
{
    using System.Xml.Serialization;

    /// <summary>
    /// 点击菜单拉取消息时的事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class FromClickEvent : FromEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromClickEvent"/> class.
        /// </summary>
        public FromClickEvent()
        {
            Event = FromEventTypes.click;
        }

        /// <summary>
        /// Gets or sets the EventKey
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}