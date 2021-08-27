
namespace WWB.Wx.Sdk.ServerMessages.From
{
    using System.Xml.Serialization;

    /// <summary>
    /// 取消关注事件
    /// </summary>
    [XmlRoot("xml")]
    public class FromUnsubscribeEvent : FromEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromUnsubscribeEvent"/> class.
        /// </summary>
        public FromUnsubscribeEvent()
        {
            Event = FromEventTypes.unsubscribe;
        }
    }
}
