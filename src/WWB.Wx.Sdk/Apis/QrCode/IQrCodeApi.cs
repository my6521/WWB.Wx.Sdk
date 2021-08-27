using System.Net.Http;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Wx.Sdk.Apis.QrCode.Dtos;

namespace WWB.Wx.Sdk.Apis.QrCode
{
    [HttpHost("https://api.weixin.qq.com/wxa/")]
    public interface IQrCodeApi : IWxApiWithAccessTokenFilter
    {
        /// <summary>
        /// 小程序一物一码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("getwxacodeunlimit")]
        Task<HttpResponseMessage> GetwxacodeUnlimit([JsonNetContent] GetWxacodeUnlimitRequest request);
    }
}
