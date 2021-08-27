using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWB.Wx.Sdk.ServerMessages.From;
using WWB.Wx.Sdk.ServerMessages.To;

namespace WWB.Wx.Sdk.ServerMessages
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
