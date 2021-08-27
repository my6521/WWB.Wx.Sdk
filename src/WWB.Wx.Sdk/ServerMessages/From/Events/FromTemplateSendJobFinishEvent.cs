
namespace WWB.Wx.Sdk.ServerMessages.From
{
    using System.Xml.Serialization;

    /// <summary>
    /// 模板消息推送成功的事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class FromTemplateSendJobFinishEvent : FromEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromTemplateSendJobFinishEvent"/> class.
        /// </summary>
        public FromTemplateSendJobFinishEvent()
        {
            Event = FromEventTypes.templatesendjobfinish;
        }

        /// <summary>
        /// Gets or sets the MsgID
        /// 消息id
        /// </summary>
        public string MsgID { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// 发送状态为成功
        /// </summary>
        public string Status { get; set; }
    }
}
