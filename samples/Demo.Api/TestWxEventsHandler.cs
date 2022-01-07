using System.Threading.Tasks;
using WWB.Wx.Sdk.AspNet.ServerMessages;
using WWB.Wx.Sdk.AspNet.ServerMessages.From;
using WWB.Wx.Sdk.AspNet.ServerMessages.To;

namespace Demo.Api
{
    public class TestWxEventsHandler : IWxEventsHandler
    {
        public Task<ToMessageBase> Execute(IFromMessage fromMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}