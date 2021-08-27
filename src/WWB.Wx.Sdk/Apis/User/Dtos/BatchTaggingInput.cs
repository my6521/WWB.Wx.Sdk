﻿using Newtonsoft.Json;

namespace WWB.Wx.Sdk.Apis.User.Dtos
{
    public class BatchTaggingInput
    {
        /// <summary>
        /// 粉丝列表
        /// </summary>
        [JsonProperty("openid_list")]
        public string[] OpenIdList { get; set; }

        [JsonProperty("tagid")]
        public int TagId { get; set; }
    }
}