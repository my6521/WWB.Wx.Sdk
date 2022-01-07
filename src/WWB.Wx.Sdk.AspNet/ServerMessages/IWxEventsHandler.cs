using System.Threading.Tasks;
using WWB.Wx.Sdk.AspNet.ServerMessages.From;
using WWB.Wx.Sdk.AspNet.ServerMessages.To;

namespace WWB.Wx.Sdk.AspNet.ServerMessages
{
    /// <summary>
    /// 微信服务消息、事件处理器
    /// </summary>
    public interface IWxEventsHandler
    {
        /// <summary>
        /// 处理服务器消息事件
        /// </summary>
        /// <param name="fromMessage"></param>
        /// <returns></returns>
        Task<ToMessageBase> Execute(IFromMessage fromMessage);
    }
}