namespace WWB.Wx.Sdk.AspNet.ServerMessages.From
{
    /// <summary>
    /// 获取消息
    /// </summary>
    public interface IFromMessage
    {
        /// <summary>
        /// Gets or sets the ToUserName
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        /// Gets or sets the FromUserName
        /// </summary>
        string FromUserName { get; set; }
    }
}