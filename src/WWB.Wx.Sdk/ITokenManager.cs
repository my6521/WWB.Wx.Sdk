using System.Threading.Tasks;

namespace WWB.Wx.Sdk
{
    public interface ITokenManager
    {
        Task<string> GetAccessTokenAsync();
    }
}