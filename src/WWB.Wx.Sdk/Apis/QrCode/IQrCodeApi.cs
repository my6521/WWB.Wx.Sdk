using System.IO;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Wx.Sdk.Apis.QrCode.Dtos;

namespace WWB.Wx.Sdk.Apis.QrCode
{
    [HttpHost("https://api.weixin.qq.com/wxa/")]
    public interface IQrCodeApi : IWxApiBase
    {
        /// <summary>
        /// 小程序一物一码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("getwxacodeunlimit")]
        Task<Stream> GetwxacodeUnlimit([PathQuery] string access_token, [JsonNetContent] GetWxacodeUnlimitRequest request);
    }
}