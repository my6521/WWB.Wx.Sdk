using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WWB.Wx.Sdk.AspNet.ServerMessages;

namespace WWB.Wx.Sdk.AspNet
{
    public static class Extentions
    {
        /// <summary>
        /// 添加服务器事件消息处理程序
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServerMessageHandler(this IServiceCollection services)
        {
            services.AddSingleton<ServerMessageHandler>();
            return services;
        }

        /// <summary>
        /// 使用分布式缓存来存储AccessToken
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWxDistributedCacheForAccessToken(this IApplicationBuilder app)
        {
            var funcs = app.ApplicationServices.GetRequiredService<WxFuncs>();
            var cache = app.ApplicationServices.GetRequiredService<IDistributedCache>();

            if (funcs.GetAccessTokenByAppId == null)
            {
                funcs.GetAccessTokenByAppId = (appid) => cache.GetString($"{WxConsts.WX_PUBLICACCOUNT_CACHE_NAMESPACE}::AT::{appid}");
            }

            if (funcs.CacheAccessToken == null)
            {
                funcs.CacheAccessToken = (appid, token) =>
                {
                    byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
                    cache.Set($"{WxConsts.WX_PUBLICACCOUNT_CACHE_NAMESPACE}::AT::{appid}", tokenBytes, new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(115)
                    });
                };
            }
            return app;
        }
    }
}