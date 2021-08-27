using WebApiClientCore.Attributes;

namespace WWB.Wx.Sdk.Apis
{
    /// <summary>
    /// 
    /// </summary>
    [JsonNetReturn(EnsureMatchAcceptContentType = false)]
    [AccessTokenApiFilter]
    [LoggingFilter]
    public interface IWxApiWithAccessTokenFilter
    {
    }
}
