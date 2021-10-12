using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WWB.Wx.Sdk.Apis;
using WWB.Wx.Sdk.Apis.CustomerService;
using WWB.Wx.Sdk.Apis.Media;
using WWB.Wx.Sdk.Apis.Menu;
using WWB.Wx.Sdk.Apis.Message;
using WWB.Wx.Sdk.Apis.QrCode;
using WWB.Wx.Sdk.Apis.Sns;
using WWB.Wx.Sdk.Apis.Token;
using WWB.Wx.Sdk.Apis.User;
using WWB.Wx.Sdk.ServerMessages;

namespace WWB.Wx.Sdk
{
    public static class Extentions
    {
        /// <summary>
        /// 添加公众号Sdk集成
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWxSdk(this IServiceCollection services)
        {
            services
                .AddWebApiClient()
                .UseJsonFirstApiActionDescriptor();

            services.AddSingleton<WxFuncs>();
            services.AddHttpApi<ITokenApi>();
            services.AddHttpApi<IOauth2Api>();
            services.AddHttpApi<ISnsApi>();
            services.AddHttpApi<ITemplateApi>();
            services.AddHttpApi<IMenuApi>();
            services.AddSingleton<ITokenManager, TokenManager>();
            services.AddHttpApi<IKfAccountApi>();
            services.AddHttpApi<IMediaApi>();
            services.AddHttpApi<IUserApi>();
            services.AddHttpApi<ITagsApi>();
            services.AddHttpApi<IQrCodeApi>();
            return services;
        }

        /// <summary>
        /// 配置公众号Sdk
        /// </summary>
        /// <param name="app"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWxSdk(this IApplicationBuilder app, Action<WxFuncs> setupAction = null)
        {
            WxFuncs funcs = app.ApplicationServices.GetRequiredService<WxFuncs>();
            setupAction?.Invoke(funcs);
            //如果没有设置获取微信配置逻辑，则自动从配置文件读取
            if (funcs.GetWeChatOptions == null)
            {
                IConfiguration config = app.ApplicationServices.GetRequiredService<IConfiguration>();
                IConfigurationSection wechatConfig = config.GetSection("Wx");
                if (wechatConfig != null)
                {
                    funcs.GetWeChatOptions = () => WxHelper.GetWeChatOptionsByConfiguration(config);
                }
            }
            return app;
        }

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


        /// <summary>
        /// 确保成功执行
        /// </summary>
        /// <param name="apiResult"></param>
        public static void EnsureSuccess(this ApiResultBase apiResult)
        {
            if (!apiResult.IsSuccess())
            {
                throw new WxSdkException(apiResult.GetFriendlyMessage());
            }
        }
    }
}