/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.Request
// 类名：QueryStatusRequest
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/10 14:14:50 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TEC.Public.Component.UMengAopSdk.Request;
using TEC.Public.Component.UMengAopSdk.Response;

namespace TEC.Public.Component.UMengAopSdk.Request
{
    public class UploadRequest : IAopRequest<UploadResponse, UploadResponse.DataModel>
    {
        /// <summary>
        /// 必填 文件内容,多个device_token/alias请用回车符"\n"分隔。
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        private const string APIPATH = "/api/upload";
        public string GetApiPath()
        {
            return APIPATH;
        }

        public string ToJSON(string appkey, string timestamp)
        {
            JObject jobject = JObject.FromObject(this);
            jobject["appkey"] = appkey;
            jobject["timestamp"] = timestamp;
            return jobject.ToString();
            //return JsonConvert.SerializeObject(new
            //{
            //    appkey = appkey,
            //    timestamp = timestamp,
            //    content = Content
            //});
        }
        public string ToJSON()
        {
            JObject jobject = JObject.FromObject(this);
            return jobject.ToString();

        }
    }
}
