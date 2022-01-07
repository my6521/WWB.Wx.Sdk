﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WWB.Wx.Sdk.Apis;
using WWB.Wx.Sdk.Apis.CustomerService;
using WWB.Wx.Sdk.Apis.Media;
using WWB.Wx.Sdk.Apis.Menu;
using WWB.Wx.Sdk.Apis.Message;
using WWB.Wx.Sdk.Apis.QrCode;
using WWB.Wx.Sdk.Apis.Sns;
using WWB.Wx.Sdk.Apis.Token;
using WWB.Wx.Sdk.Apis.User;

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