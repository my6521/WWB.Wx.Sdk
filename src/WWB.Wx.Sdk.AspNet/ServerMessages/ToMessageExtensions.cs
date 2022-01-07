using WWB.Wx.Sdk.AspNet.ServerMessages.To;
using WWB.Wx.Sdk.Helper;

namespace WWB.Wx.Sdk.AspNet.ServerMessages
{
    /// <summary>
    /// 发送消息扩展
    /// </summary>
    public static class ToMessageExtensions
    {
        /// <summary>
        /// 序列化XML
        /// </summary>
        /// <param name="msg">发送消息</param>
        /// <returns></returns>
        public static string ToXml(this ToMessageBase msg)
        {
            //移除定义和命名空间
            return msg == null ? null : XmlHelper.SerializeObjectWithoutNamespace(msg);
        }
    }
}